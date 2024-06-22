using System.Text;
using System.Text.RegularExpressions;

namespace Translator;

public class Translator
{
    // [0] Lower case words, [1] Title case words, [2] Upper case words, [3] Numbers, [4] Spaces, [5] any non-word characters.
    private string[] patterns = [@"[a-z]+", @"^[A-Z][a-z]+", @"[A-Z]+", @"\d+", @"\s+", @"\W+"];
    private Dictionary<string, string> dictionary = new();

    public void Register(string word, string meaning)
    {
        dictionary[word.ToLower()] = meaning.ToLower();
    }

    public string Translate(string text)
    {
        // Using string builder for memory performance because the string type is immutable.
        var input = new StringBuilder(text);
        var output = new StringBuilder();

        // The time complexity here is linear O(n) where n = input.Length
        while (input.Length > 0)
        {
            // The time complexity here is constant O(1) because there are just 6 patterns.
            for (int i = 0; i < patterns.Length; i++)
            {
                var match = Regex.Match(input.ToString(), "^" + patterns[i]);
                if (match.Success)
                {
                    var token = match.Value;
                    // Check the words only
                    if ((i == 0 || i == 1 || i == 2) && dictionary.ContainsKey(match.Value.ToLower()))
                    {
                        token = dictionary[match.Value.ToLower()];
                        // Title case
                        if (i == 1)
                        {
                            token = token.Replace(token[0], Char.ToUpper((token[0])));
                        }

                        // Upper case
                        if (i == 2)
                        {
                            token = token.ToUpper();
                        }
                    }

                    output.Append(token);
                    input.Remove(0, match.Value.Length);
                    break;
                }
            }
        }

        return output.ToString();
    }
}
