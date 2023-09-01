using FluentAssertions;
using WordOccurrence;

namespace UnitTestWordOccurrence;

public class UnitTestTxtFileLoader
{
    private readonly TxtFileLoader _txtFileLoader;

    public UnitTestTxtFileLoader()
    {
        _txtFileLoader = new TxtFileLoader();
    }

    [Fact]
    public async Task ShouldLoadFileToArray()
    {
        //assert
        var expected = new string[] { "this", "is", "a", "Test", "file" };
        //act
        var result = await _txtFileLoader.ReadTxtFileAsync("test.txt");
        //assert
        result.Should().BeEquivalentTo(expected);

    }
}