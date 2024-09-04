using System.Linq.Expressions;

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

            LockPositions();
            Randomize(rand);
        }

        return data;
    }

    public bool IsSorted() {
        for (int i = 0; i < data.Length - 1; i++) {
            if (data[i] > data[i + 1]) return false;
        }

        return true;
    }

    public void LockPositions() {
        for (int i = 0; i < data.Length; i++) {
            if (lockedPositions[i]) continue;

            int num = data[i];
            bool setCorrect = true;
            for (int j = 0; j < data.Length; j++) {
                if (lockedPositions[j]) continue;

                int check = data[j];
                if ((j < i && check > num) || (j > i && check < num)) {
                    setCorrect = false;
                    break;
                }
            }

            if (setCorrect) {
                lockedPositions[i] = true;
            }
        }
    }

    public void Randomize(Random r) {
        List<int> swapped = new ();
        var allRemaining = lockedPositions.Where(p => !p.Value).Select(p => p.Key);

        // some shortcuts because I'm not a monster
        if (allRemaining.Count() == 0) {
            return;
        } else if (allRemaining.Count() == 2) {
            int posA = allRemaining.First(), posB = allRemaining.Last();

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