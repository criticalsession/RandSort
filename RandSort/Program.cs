using System.Diagnostics;

namespace RandSort {
    internal class Program {
        static async Task Main(string[] args) {
            Random r = new Random();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int size = 1_000, chunkSize = 200;

            int[] data = new int[size];
            for (int i = 0; i < size; i++) {
                data[i] = r.Next(1, 1_000_000);
            }

            await RandSorter.Sort(data, chunkSize);

            sw.Stop();
            Console.WriteLine($"Size: {size}; Chunks: {chunkSize}; Time: {sw.ElapsedMilliseconds}ms");
            sw.Reset();
        }
    }
}
