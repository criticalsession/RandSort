namespace RandSort;

public class IntSorter {
    private int[] data;
    private bool[] lockedPositions;

    public IntSorter(int[] data) {
        this.data = data;
        lockedPositions = new bool[data.Length];
    }

    public int[] Sort(CancellationToken token) {
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
            if (token.IsCancellationRequested) break;

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
                int check = data[j];
                if ((j < i && check > num) || (j > i && check < num)) {
                    setCorrect = false;
                    break;
                }
            }

            lockedPositions[i] = setCorrect;
        }
    }

    public void Randomize(Random r) {
        for (int i = 0; i < data.Length; i++) {
            if (lockedPositions[i]) continue;

            int newPlace = r.Next(0, data.Length);
            while (lockedPositions[newPlace]) {
                newPlace = r.Next(0, data.Length);
            }

            int temp = data[newPlace];
            data[newPlace] = data[i];
            data[i] = temp;
        }
    }
}