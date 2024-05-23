using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    const string _promptText = "Please input message: ";
    const string _invalidInputText = "Invalid Input!";

    static readonly string[] morseCode =
    [
        ".-",
        "-...",
        "-.-.",
        "-..",
        ".",
        "..-.",
        "--.",
        "....",
        "..",
        ".---",
        "-.-",
        ".-..",
        "--",
        "-.",
        "---",
        ".--.",
        "--.-",
        ".-.",
        "...",
        "-",
        "..-",
        "...-",
        ".--",
        "-..-",
        "-.--",
        "--.."
    ];

    private static string CharToMorse(char c)
    {
        if ('A' <= c && c <= 'Z')
        {
            return morseCode[c - 'A'];
        }

        return "UNKNOWN";
    }

    private static char MorseToUpperChar(string m)
    {
        for (int i = 0; i < 26; ++i)
        {
            if (m == morseCode[i])
            {
                return (char)('A' + i);
            }
        }
        return '?';
    }

    private static string EncodeMorse(string message)
    {
        List<string> morseCode = [];
        foreach (char c in message)
        {
            morseCode.Add(CharToMorse(c));
        }

        return string.Join(' ', morseCode);
    }

    private static string DecodeMorse(string message)
    {
        string[] morseCodes = message.Split();
        string retStr = string.Empty;
        foreach (string str in morseCodes)
        {
            retStr += MorseToUpperChar(str);
        }

        return retStr;
    }

    private static bool IsMorse(char c)
    {
        return c == '-' || c == '.' || c == ' ';
    }

    static void Main()
    {
        Console.WriteLine(_promptText);
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(_invalidInputText);
        }
        else if (input.All(IsMorse))
        {
            Console.WriteLine(DecodeMorse(input));
        }
        else if (input.All(char.IsAsciiLetterUpper))
        {
            Console.WriteLine(EncodeMorse(input));
        }
        else
        {
            Console.WriteLine(_invalidInputText);
        }

        return;
    }
}