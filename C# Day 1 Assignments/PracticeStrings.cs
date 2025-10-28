using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C__Day_1_Assignments {
    internal class PracticeStrings {
        public void ReverseStringUsingCharArray(string input) {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);
            Console.WriteLine(reversedString);
        }

        public void ReverseStringUsingForLoop(string input) {
            for (int i = input.Length - 1; i >= 0; i--) {
                Console.Write(input[i]);
            }
        }

        public string ReverseSentence(string sentence) {
            char[] separators = { '.', ',', ';', ':', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '|', '?', ' ', '!' };

            List<string> words = new List<string>();
            List<string> seps = new List<string>();

            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < sentence.Length; i++) {
                char c = sentence[i];

                if (IsSeparator(c, separators)) {
                    if (currentWord.Length > 0) {
                        words.Add(currentWord.ToString());
                        currentWord.Clear();
                    }
                    seps.Add(c.ToString());
                } else {
                    currentWord.Append(c);
                }
            }
            if (currentWord.Length > 0) {
                words.Add(currentWord.ToString());
            }

            // Reverse the words list
            words.Reverse();

            StringBuilder result = new StringBuilder();
            int wordIndex = 0;

            for (int i = 0; i < seps.Count; i++) {
                if (wordIndex < words.Count) {
                    result.Append(words[wordIndex]);
                    wordIndex++;
                }

                // Add separator
                result.Append(seps[i]);
            }

            // Add remaining word if the sentence doesn't end with separator
            if (wordIndex < words.Count) {
                result.Append(words[wordIndex]);
            }

            return result.ToString();
        }

        public bool IsSeparator(char c, char[] separators) {
            foreach (char sep in separators) {
                if (c == sep)
                    return true;
            }
            return false;
        }

        public void FindPalindromes(string words) {
            MatchCollection matches = Regex.Matches(words, @"\b\w+\b");
            HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match match in matches) {
                string word = match.Value;
                string reversed = new string(word.Reverse().ToArray());
                if (word.Equals(reversed, StringComparison.OrdinalIgnoreCase)) {
                    uniqueWords.Add(word);
                }
            }
            List<string> palindromes = uniqueWords.ToList();
            palindromes.Sort(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < palindromes.Count; i++) {
                if(i == palindromes.Count - 1) {
                    Console.Write(palindromes[i]);
                } else {
                    Console.Write(palindromes[i] + ", ");
                }
            }
        }

        public void ParseUrl(string url) {
            string pattern = @"^(?:([^:/?#]+)://)?([^/?#]+)(?:/([^?#]*))?$";

            Match match = Regex.Match(url, pattern);

            if (!match.Success) {
                Console.WriteLine("Invalid URL format");
                return;
            }

            string protocol = match.Groups[1].Success ? match.Groups[1].Value : "";
            string server = match.Groups[2].Value;
            string resource = match.Groups[3].Success ? match.Groups[3].Value : "";

            // Print results
            if (!string.IsNullOrEmpty(protocol)) {
                Console.WriteLine($"[protocol] = \"{protocol}\"");
            }

            Console.WriteLine($"[server] = \"{server}\"");

            if (!string.IsNullOrEmpty(resource)) {
                Console.WriteLine($"[resource] = \"{resource}\"");
            }
        }
    }
}
