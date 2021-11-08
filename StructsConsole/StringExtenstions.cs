using System;
using System.Collections.Generic;
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
            Stack<char> openChars = new();
            for (var i = 0; i < sbTask.Length; i++)
            {
                if (openChars.Count != 0 && sbTask[i] == replaceableChar) sbTask[i] = swapChar;
                openChars.TryPeek(out var openChar);
                if (str[i] == GetCloseChar(openChar)) openChars.Pop();
                if (str[i] is '(' or '{' or '[' or '"' or '\'') openChars.Push(str[i]);
            }
            return sbTask.ToString();
        }

        private static char? GetCloseChar(char openChar) => openChar switch
        {
            '{' => '}',
            '(' => ')',
            '[' => ']',
            '\'' => '\'',
            '\"' => '\"',
            _ => null
        };
    }
}