using System;
using System.Linq;
using System.Text;

namespace StructsConsole
{
    public static class StringExtensions
    {
        public static void DeleteControlChars(this string str)
        {
            str = string.Concat(str.Where(x => !char.IsControl(x)));
        }
        internal static string TakeMiddlePart(this string str, char keySymbol, char keySymbol2 = '\0')
        {
            if (keySymbol2 == '\0') keySymbol2 = keySymbol;
            var firstIndex = str.IndexOf(keySymbol);
            var lastIndex = str.LastIndexOf(keySymbol2);
            return str.Substring(firstIndex + 1,  str.Length - firstIndex - (str.Length - lastIndex) - 1);
        }
        
        //Comma = | Space = /
        internal static string[] SaveOnlyMainSymbolsAndSplit(this string str, char replaceableChar)
        {
            str = SaveOnlyMainSymbols(str, replaceableChar);
            return str
                .Split(replaceableChar, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Replace('⍔', replaceableChar))
                .ToArray();
        }

        private static string SaveOnlyMainSymbols(string str, char replaceableChar)
        {
            var swapChar = '⍔';
            var sbTask = new StringBuilder(str);
            var firstSymFound = false;
            for (var i = 0; i < sbTask.Length; i++)
            {
                if (firstSymFound && sbTask[i] == replaceableChar) sbTask[i] = swapChar;
                if (str[i] is '{' or '}' or '(' or ')' or '\'' or '\"') firstSymFound = !firstSymFound;
            }
            return sbTask.ToString();
        }
    }
}