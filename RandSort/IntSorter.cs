namespace RandSort;

public class IntSorter {
    private int[] data;
    private Dictionary<int, bool> lockedPositions;

    public IntSorter(int[] data) {
        this.data = data;
        lockedPositions = new();
        for (int i = 0; i < data.Length; i++) {
            lockedPositions[i] = false;
        }
    }

    public int[] Sort() {
        if (data.Length < 2) return data;
        if (data.Length == 2) {
            if (data[0] > data[1]) {
                return [data[1], data[0]];
            } else {
                return data;
            }
        }

        Random rand = new Random();

        while (true) {
            if (IsSorted()) break;
            Randomize(rand);
        }

        return data;
    }

    public bool IsSorted() {
        int n = data.Length;
        int[] leftMax = new int[n];
        int[] rightMin = new int[n];

        leftMax[0] = data[0];
        for (int i = 1; i < n - 1; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], data[i]);
        }

        rightMin[n - 1] = data[n - 1];
        for (int i = data.Length - 2; i >= 0; i--) {
            rightMin[i] = Math.Min(rightMin[i + 1], data[i]);
        }

        bool allCorrect = true;
        for (int i = 0; i < n; i++) {
            if (lockedPositions[i]) continue;

            bool leftLock = (i == 0) || (data[i] >= leftMax[i - 1]);
            bool rightLock = (i == n - 1) || (data[i] <= rightMin[i + 1]);

            if (leftLock && rightLock) {
                lockedPositions[i] = true;
            }
            else
            {
                allCorrect = false;
            }
        }

        return allCorrect;
    }

    public void Randomize(Random r) {
        List<int> swapped = new ();
        int[] allRemaining = lockedPositions.Where(p => !p.Value).Select(p => p.Key).ToArray();

        // some shortcuts because I'm not a monster
        if (allRemaining.Length == 0) {
            return;
        } else if (allRemaining.Length == 2) {
            int posA = allRemaining.First(), 
                posB = allRemaining.Last();

            int temp = data[posA];
            data[posA] = data[posB];
            data[posB] = temp;

            return;
        }

        for (int i = 0; i < data.Length; i++) {
            if (lockedPositions[i]) continue;
            if (swapped.Contains(i)) continue;

            var remaining = allRemaining.Where(p => !swapped.Contains(p) && p != i);
            if (remaining.Count() == 0) break;

            int newPlace = remaining.ElementAt(r.Next(0, remaining.Count()));

            // swap
            int temp = data[newPlace];
            data[newPlace] = data[i];
            data[i] = temp;

            // skip these two positions for the rest of the loop
            swapped.Add(i);
            swapped.Add(newPlace);
        }
    }
}