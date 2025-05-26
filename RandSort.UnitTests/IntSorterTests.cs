namespace RandSort.UnitTests;

[TestFixture]
public class IntSorterTests {
    [Test]
    public void Sort_EmptyArray_ReturnsEmptyArray() {
        // Arrange
        var data = Array.Empty<int>();
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Sort_SingleElement_ReturnsSameElement() {
        // Arrange
        var data = new[] { 42 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(data));
    }

    [Test]
    public void Sort_TwoElements_SortsCorrectly() {
        // Arrange
        var data = new[] { 2, 1 };
        var expected = new[] { 1, 2 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_TwoElementsAlreadySorted_ReturnsSameArray() {
        // Arrange
        var data = new[] { 1, 2 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(data));
    }

    [Test]
    public void Sort_BasicArray_ReturnsSortedArray() {
        // Arrange
        var data = new[] { 5, 3, 1, 4, 2 };
        var expected = new[] { 1, 2, 3, 4, 5 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_DuplicateValues_ReturnsSortedArray() {
        // Arrange
        var data = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
        var expected = new[] { 1, 1, 2, 3, 3, 4, 5, 5, 6, 9 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_NegativeNumbers_ReturnsSortedArray() {
        // Arrange
        var data = new[] { -5, -3, -1, -4, -2 };
        var expected = new[] { -5, -4, -3, -2, -1 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_MixedNumbers_ReturnsSortedArray() {
        // Arrange
        var data = new[] { -5, 3, 0, -4, 2 };
        var expected = new[] { -5, -4, 0, 2, 3 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_AlreadySorted_ReturnsSameArray() {
        // Arrange
        var data = new[] { 1, 2, 3, 4, 5 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(data));
    }

    [Test]
    public void Sort_ReverseSorted_ReturnsSortedArray() {
        // Arrange
        var data = new[] { 5, 4, 3, 2, 1 };
        var expected = new[] { 1, 2, 3, 4, 5 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_LargeArray_ReturnsSortedArray() {
        // Arrange
        var rand = new Random(42);
        var data = new int[100];
        for (int i = 0; i < data.Length; i++) {
            data[i] = rand.Next(-1000, 1000);
        }
        var expected = new int[data.Length];
        Array.Copy(data, expected, data.Length);
        Array.Sort(expected);

        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Constructor_NullArray_ThrowsArgumentNullException() {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new IntSorter(null!));
    }

    [Test]
    public void Sort_ModifiesOriginalArray() {
        // Arrange
        var data = new[] { 5, 3, 1, 4, 2 };
        var originalData = new[] { 5, 3, 1, 4, 2 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(data), "Returned array should be the same instance as input array");
        Assert.That(data, Is.Not.EqualTo(originalData), "Original array should be modified");
        Assert.That(data, Is.Ordered, "Array should be sorted");
    }

    [TestCase(new[] { 3, 1, 4 }, new[] { 1, 3, 4 })]
    [TestCase(new[] { 5, 2, 8, 1, 9 }, new[] { 1, 2, 5, 8, 9 })]
    [TestCase(new[] { 1, 1, 2, 2, 3 }, new[] { 1, 1, 2, 2, 3 })]
    public void Sort_VariousInputs_ReturnsSortedArray(int[] input, int[] expected) {
        // Arrange
        var sorter = new IntSorter(input);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_MaxIntValues_ReturnsSortedArray() {
        // Arrange
        var data = new[] { int.MaxValue, 0, int.MinValue };
        var expected = new[] { int.MinValue, 0, int.MaxValue };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sort_AllSameValues_ReturnsSameArray() {
        // Arrange
        var data = new[] { 1, 1, 1, 1, 1 };
        var sorter = new IntSorter(data);

        // Act
        var result = sorter.Sort();

        // Assert
        Assert.That(result, Is.EqualTo(data));
    }
}