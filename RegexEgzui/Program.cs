using System;
using System.Text.RegularExpressions;

namespace RegexEgzui
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(InOut.ReadLongestWord());
        }
    }

    public static class InOut
    {
        public static string ReadLongestWord(string fin = @"../../../Tekstas.csv", int K = 3, string punctuation = " ")
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;
                string longest = "";

                while ((line = reader.ReadLine()) != null)
                {
                    string regex = $"([^{punctuation}]+)([{punctuation}]*)";

                    foreach (Match match in Regex.Matches(line, regex))
                    {
                        int count = 0;
                        char[] characters = new char[K + 1];
                        string word = match.Groups[1].Value;

                        foreach (char ch in word)
                        {
                            if (!characters.Contains(ch) && count < K + 1)
                            {
                                characters[count] = ch;
                                count++;
                            }
                            if (count == K + 1)
                            {
                                break;
                            }
                        }

                        if (count <= K && word.Length > longest.Length)
                        {
                            longest = word;
                        }
                    }
                }

                return longest;
            }
        }
    }
}
