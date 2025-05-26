namespace RandSort;

public class IntSorter {
    private int[] _data;
    private Dictionary<int, bool> _lockedPositions;

    public IntSorter(int[] data) {
        _data = data;
        _lockedPositions = new Dictionary<int, bool>();
        for (var i = 0; i < data.Length; i++) {
            _lockedPositions[i] = false;
        }
    }

    public int[] Sort() {
        switch (_data.Length)
        {
            case < 2:
                return _data;
            case 2:
                return _data[0] > _data[1] ? [_data[1], _data[0]] : _data;
        }

        var rand = new Random();

        while (true) {
            if (IsSorted()) break;
            Randomize(rand);
        }

        return _data;
    }

    private bool IsSorted() {
        var n = _data.Length;
        var leftMax = new int[n];
        var rightMin = new int[n];

        leftMax[0] = _data[0];
        for (var i = 1; i < n - 1; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], _data[i]);
        }

        rightMin[n - 1] = _data[n - 1];
        for (var i = _data.Length - 2; i >= 0; i--) {
            rightMin[i] = Math.Min(rightMin[i + 1], _data[i]);
        }

        var allCorrect = true;
        for (var i = 0; i < n; i++) {
            if (_lockedPositions[i]) continue;

            var leftLock = (i == 0) || (_data[i] >= leftMax[i - 1]);
            var rightLock = (i == n - 1) || (_data[i] <= rightMin[i + 1]);

            if (leftLock && rightLock) {
                _lockedPositions[i] = true;
            }
            else
            {
                allCorrect = false;
            }
        }

        return allCorrect;
    }

    private void Randomize(Random r) {
        List<int> swapped = [];
        var allRemaining = _lockedPositions.Where(p => !p.Value).Select(p => p.Key).ToArray();

        // some shortcuts because I'm not a monster
        switch (allRemaining.Length)
        {
            case 0:
                return;
            case 2:
            {
                int posA = allRemaining.First(), 
                    posB = allRemaining.Last();

                (_data[posA], _data[posB]) = (_data[posB], _data[posA]);
                return;
            }
        }

        for (int i = 0; i < _data.Length; i++) {
            if (_lockedPositions[i]) continue;
            if (swapped.Contains(i)) continue;

            var remaining = allRemaining.Where(p => !swapped.Contains(p) && p != i)
                .ToArray();
            if (remaining.Length == 0) break;

            var newPlace = remaining.ElementAt(r.Next(0, remaining.Length));

            // swap
            (_data[newPlace], _data[i]) = (_data[i], _data[newPlace]);

            // skip these two positions for the rest of the loop
            swapped.Add(i);
            swapped.Add(newPlace);
        }
    }
}