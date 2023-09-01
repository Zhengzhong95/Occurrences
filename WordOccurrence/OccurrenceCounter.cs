using System.Collections.Concurrent;

namespace WordOccurrence;

public interface IOccurrenceCounter
{
    Task<ConcurrentDictionary<string, int>> CountFromPathsAsync(string[] paths);
}


public class OccurrenceCounter: IOccurrenceCounter
{
    private readonly ITxtFileLoader _fileLoader;
    
    public OccurrenceCounter(ITxtFileLoader fileLoader)
    {
        _fileLoader = fileLoader;
    }

    public async Task<ConcurrentDictionary<string, int>> CountFromPathsAsync(string[] paths)
    {
        var wordCounter = new ConcurrentDictionary<string, int>();
        var tasks = paths.Select(path => Task.Run(async () =>
            {
                var words = await _fileLoader.ReadTxtFileAsync(path);
                foreach (var word in words)
                {
                    wordCounter.AddOrUpdate(word, 1, (_, currentCount) => currentCount + 1);
                }
            }))
            .ToList();

        await Task.WhenAll(tasks);
        return wordCounter;
    }
}