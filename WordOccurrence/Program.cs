using WordOccurrence;

var directoryPath = "../../../TxtFiles";
var txtPaths = Directory.GetFiles(directoryPath, "*.txt");
ITxtFileLoader fileLoader = new TxtFileLoader();
IOccurrenceCounter counter = new OccurrenceCounter(fileLoader);
var wordOccurrences = await counter.CountFromPathsAsync(txtPaths);

foreach (var pair in wordOccurrences)
{
    Console.WriteLine($"{pair.Key}:{pair.Value}");
}