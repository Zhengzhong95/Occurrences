using FluentAssertions;
using NSubstitute;
using WordOccurrence;

namespace UnitTestWordOccurrence;

public class UnitTestOccurrenceCounter
{
    private readonly ITxtFileLoader _txtFileLoader;
    private readonly OccurrenceCounter _counter;

    public UnitTestOccurrenceCounter()
    {
        _txtFileLoader = Substitute.For<ITxtFileLoader>();
        _counter = new OccurrenceCounter(_txtFileLoader);
    }

    [Fact]
    public async Task ShouldCountOccurrence()
    {
        //arrange
        _txtFileLoader.ReadTxtFileAsync(Arg.Any<string>()).Returns(new string[] { "hello","world" });
        var path = new string[] {"path1", "path2"};
        //act
        var result = await _counter.CountFromPathsAsync(path);
        //assert
        result["hello"].Should().Be(2);
        result["world"].Should().Be(2);
    }
    
    


}