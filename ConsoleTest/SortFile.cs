using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class SortFile
    {
        private string[] _usingTypes = Array.Empty<string>();
        private readonly string _mainPath;
        private readonly string _firstTempPath = Path.Combine(Environment.CurrentDirectory, "temp1.txt");
        private readonly string _secondTempPath = Path.Combine(Environment.CurrentDirectory, "temp2.txt");
        private int _compareIndex;
        private int _linesCount;
        
        public Action<string> ShowInfo { get; set; }
        
        public SortFile(string path, Action<string> showAction)
        {
            _mainPath = path;
            ShowInfo = showAction;
            _linesCount = File.ReadLines(_mainPath).Count();
        }
        private void ParseHeader(string path)
        {
            var lines = File.ReadAllLines(path);
            _usingTypes = lines[0].Split(' ');
        }
        
        public void SortByFiles(int index)
        {
            _compareIndex = index;
            File.Create(_firstTempPath).Close();
            File.Create(_secondTempPath).Close();

            ParseHeader(_mainPath);
            
            //How many iterations are needed to sort excluding header (-1)
            var linesCount = File.ReadLines(_mainPath).Count(line => !string.IsNullOrWhiteSpace(line)) - 1;
            var partitionsNumber = (int)Math.Ceiling(Math.Log(linesCount, 2));
            
            for (var i = 0; i < partitionsNumber; i++)
            {
                TakeElements((int)Math.Pow(2, i));
            }
            
            File.Delete(_firstTempPath);
            File.Delete(_secondTempPath);
        }
        private void TakeElements(int elementsCount)
        {
            var counter = 0;
            using (StreamWriter tempWriter1 = new(_firstTempPath), tempWriter2 = new(_secondTempPath))
            using (var reader = new StreamReader(_mainPath))
            {
                reader.ReadLine();
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (counter % (elementsCount + 1) == 0) tempWriter1.WriteLine(line);
                    else tempWriter2.WriteLine(line);
                    
                    counter++;
                    line = reader.ReadLine();
                }
            }
            
            ShowInfo(string.Join('\n', File.ReadLines(_firstTempPath)) + '\n');
            ShowInfo(string.Join('\n', File.ReadLines(_secondTempPath)) + '\n');
            File.Create(_mainPath).Dispose();
            
            MergeTempFiles();
            ShowInfo(string.Join('\n', File.ReadLines(_mainPath)));
        }
        
        private void MergeTempFiles()
        {
            using StreamReader reader1 = new(_firstTempPath), reader2 = new(_secondTempPath);
            using var writer = new StreamWriter(_mainPath);
            
            var str1 = reader1.ReadLine();
            var str2 = reader2.ReadLine();
            
            writer.WriteLine(string.Join(' ', _usingTypes));
            
            while (!string.IsNullOrWhiteSpace(str1) && !string.IsNullOrWhiteSpace(str2))
            {
                ShowInfo($"Сравниваем {str1} и {str2}");
                var compareResult = Compare(str1, str2);
                if (compareResult <= 0)
                {
                    ShowInfo($"Записываем {str1}");
                    writer.WriteLine(str1);
                    str1 = reader1.ReadLine();
                    //fileCounter1++;
                }
                else
                {
                    ShowInfo($"Записываем {str2}");
                    writer.WriteLine(str2);
                    str2 = reader2.ReadLine();
                    //fileCounter2++;
                }
            }
            
            
            var reader3 = string.IsNullOrWhiteSpace(str1) ? reader2 : reader1;
            var str3 = string.IsNullOrWhiteSpace(str1) ? str2 : str1;
            
            while (!string.IsNullOrWhiteSpace(str3))
            {
                ShowInfo($"\nЗаписываем остатки {str3}\n");
                writer.WriteLine(str3);
                str3 = reader3.ReadLine();
            }
        }
        private int Compare(string str1, string str2)
        {
            return _usingTypes[_compareIndex] switch
            {
                "int" => int.Parse(str1.Split(' ')[_compareIndex]).CompareTo(int.Parse(str2.Split(' ')[_compareIndex])),
                "float" => float.Parse(str1.Split(' ')[_compareIndex])
                    .CompareTo(float.Parse(str2.Split(' ')[_compareIndex])),
                "string" => string.CompareOrdinal(str1.Split(' ')[_compareIndex], str2.Split(' ')[_compareIndex]),
                _ => throw new NotImplementedException()
            };
        }
    }
}