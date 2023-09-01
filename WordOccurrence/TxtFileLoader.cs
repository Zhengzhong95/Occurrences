using System.Text;

namespace WordOccurrence;

public interface ITxtFileLoader
{
    Task<string[]> ReadTxtFileAsync(string path);
}


public class TxtFileLoader: ITxtFileLoader
{
    public async Task<string[]> ReadTxtFileAsync(string path)
    {
        var content = await File.ReadAllTextAsync(path);
        return SplitWords(content);
    }
    
    private string[] SplitWords(string content)
    {
        var words = new List<string>();
        var sb = new StringBuilder();
        foreach (var ch in content)
        {
            if (char.IsLetter(ch))
            {
                sb.Append(ch);
            }
            else if(sb.Length > 0)
            {
                words.Add(sb.ToString());
                sb.Clear();
            }
        }
        if (sb.Length > 0)
        {
            words.Add(sb.ToString());
        }
        return words.ToArray();
    }
    
}