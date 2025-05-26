namespace RandSort.UnitTests;

[TestFixture]
public class RandSorterTests {
    [Test]
    public async Task Sort_EmptyArray_ReturnsEmptyArray() {
        // Arrange
        int[] data = Array.Empty<int>();

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result.Length, Is.EqualTo(0));
    }

    [Test]
    public async Task Sort_SingleElement_ReturnsSameElement() {
        // Arrange
        int[] data = [42];

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(data));
    }

    [Test]
    public async Task Sort_BasicArray_ReturnsSortedArray() {
        // Arrange
        int[] data = [5, 3, 1, 4, 2];
        int[] expected = [1, 2, 3, 4, 5];

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Sort_WithCustomChunkSize_ReturnsSortedArray() {
        // Arrange
        int[] data = [8, 6, 4, 2, 7, 5, 3, 1];
        int[] expected = [1, 2, 3, 4, 5, 6, 7, 8];
        int chunkSize = 3;

        // Act
        var result = await RandSorter.Sort(data, chunkSize);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Sort_LargeArray_ReturnsSortedArray() {
        // Arrange
        int size = 1000;
        int[] data = new int[size];
        Random rand = new(42);
        for (int i = 0; i < size; i++) {
            data[i] = rand.Next(-1000, 1000);
        }
        int[] expected = new int[size];
        Array.Copy(data, expected, size);
        Array.Sort(expected);

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Sort_DuplicateValues_ReturnsSortedArray() {
        // Arrange
        int[] data = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3];
        int[] expected = [1, 1, 2, 3, 3, 4, 5, 5, 6, 9];

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Sort_AlreadySorted_ReturnsSameArray() {
        // Arrange
        int[] data = [1, 2, 3, 4, 5];
        int[] expected = [1, 2, 3, 4, 5];

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Sort_NegativeNumbers_ReturnsSortedArray() {
        // Arrange
        int[] data = [-5, -3, -1, -4, -2];
        int[] expected = [-5, -4, -3, -2, -1];

        // Act
        var result = await RandSorter.Sort(data);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}