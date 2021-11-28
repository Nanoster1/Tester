using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public class Task3
    {
        public Task3(string text)
        {
            Text = ParseToChar(text);
        }
        public string[] Text { get; set; } 
        private string[] ParseToChar(string text)
        {
            string[] parseText = text.Split(" ");
            for (int i = 0; i < parseText.Length; i++)
            {
                parseText[i] = parseText[i].Trim(new char[] { ',', '.', '?', '!', ':', ';', '(', ')' });
            }
            return parseText;
        }
        public static Dictionary<string, int> Count(string[] text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (dictionary.ContainsKey(text[i]))
                    dictionary[text[i]]++;
                else
                    dictionary.Add(text[i], 1);
            }
            return dictionary;
        }

    }
}
