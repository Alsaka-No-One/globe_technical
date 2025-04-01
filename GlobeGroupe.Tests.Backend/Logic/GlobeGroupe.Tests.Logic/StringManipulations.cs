namespace GlobeGroupe.Tests.Logic;

public static class StringManipulations
{
    /// <summary>
    /// Reverses the characters in the given string.
    /// </summary>
    /// <param name="input">The string to reverse.</param>
    /// <returns>A new string with the characters in reverse order.</returns>
    /// <example>
    /// <code>
    /// string result = StringManipulations.Reverse("hello");
    /// // result: "olleh"
    /// </code>
    /// </example>
    public static string Reverse(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        int startIndex = 0;
        int endIndex = input.Length - 1;
        char[] inputArray = input.ToCharArray();

        while (startIndex < endIndex)
        {
            char temp = inputArray[startIndex];
            inputArray[startIndex] = inputArray[endIndex];
            inputArray[endIndex] = temp;
            startIndex++;
            endIndex--;
        }
        // use of IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source) is forbidden
        return new string(inputArray);    
    }

    /// <summary>
    /// Capitalizes the first letter of each word in the given string.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>A new string with the first letter of each word capitalized.</returns>
    /// <example>
    /// <code>
    /// string result = StringManipulations.CapitalizeWords("hello world");
    /// // result: "Hello World"
    /// </code>
    /// </example>
    public static string CapitalizeWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input;
        }

        IEnumerable<string> wordsList = input.Split(" ").Select(word => char.ToUpper(word[0]) + word.Substring(1));
        return string.Join(" ", wordsList);
    }

    /// <summary>
    /// Determines whether the given string is a palindrome.
    /// don't take into account spaces, or capitalization. (ex: "race, Car" is a palindrome)
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string is a palindrome; otherwise, false.</returns>
    /// <example>
    /// <code>
    /// bool result = StringManipulations.IsPalindrome("racecar");
    /// // result: true
    /// </code>
    /// </example>
    public static bool IsPalindrome(string input)
    {
        if (input == null)
        { 
            throw new ArgumentNullException(nameof(input));
        }

        string inputClean = new string(input
            .Where(char.IsLetter)
            .Select(char.ToLower)
            .ToArray());

        return inputClean == Reverse(inputClean);
    }
}
