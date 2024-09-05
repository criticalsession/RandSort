namespace RandomSort;
public class RandSorter {
    /// <summary>
    /// Sorts data using random swapping. Horribly inefficient. Do not use.
    /// </summary>
    /// <param name="data">Array to sort</param>
    /// <param name="chunkSize">Size of chunks to split source array into different tasks</param>
    /// <returns>Returns sorted array... eventually</returns>
    public static async Task<int[]> Sort(int[] data, int chunkSize = 200) {
        int totalTasks = (int)Math.Ceiling(data.Length / (double)chunkSize);

        List<Task<int[]>> tasks = new();
        for (int i = 0; i < totalTasks; i++) {
            int start = i * chunkSize;
            int length = Math.Min(chunkSize, data.Length - start);

            tasks.Add(Task.Run(() => {
                int[] chunk = new int[length];
                Array.Copy(data, start, chunk, 0, length);

                IntSorter sorter = new(chunk);
                return sorter.Sort();
            }));
        }

        int[][] sortedChunks = await Task.WhenAll(tasks);
        return ProcessChunks(sortedChunks, data.Length);
    }

    private static int[] ProcessChunks(int[][] chunks, int length) {
        int[] result = new int[length];

        int[] chunkPointers = new int[chunks.Length];
        Array.Fill(chunkPointers, 0);

        int resultPointer = 0, chunkIdx = 0, minValue = int.MaxValue;
        while (resultPointer < result.Length) {
            for (int i = 0; i < chunks.Length; i++) {
                if (chunkPointers[i] >= chunks[i].Length) continue; // chunk exhausted

                int checkNum = chunks[i][chunkPointers[i]];
                if (checkNum < minValue) {
                    minValue = checkNum;
                    chunkIdx = i;
                }
            }

            result[resultPointer++] = minValue;
            chunkPointers[chunkIdx]++;

            minValue = int.MaxValue;
        }

        return result;
    }
}
