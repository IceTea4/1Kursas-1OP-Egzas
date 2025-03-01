using System;
using System.Text.RegularExpressions;

namespace RegexEgzui2
{
    public static class TaskUtils
    {
        public static bool FirstLit(string file, string punctuation, out string word)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                string litovski = "ąčęėįšųūž";

                while ((line = reader.ReadLine()) != null)
                {
                    string regex = $"([^{punctuation}]+)([{punctuation}]*)";

                    foreach (Match match in Regex.Matches(line, regex))
                    {
                        string vordas = match.Groups[1].Value.ToLower();

                        foreach (char letter in litovski)
                        {
                            if (vordas.IndexOf(letter) != vordas.LastIndexOf(letter))
                            {
                                word = vordas;
                                return true;
                            }
                        }
                    }
                }

                word = "";
                return false;
            }
        }
    }
}
