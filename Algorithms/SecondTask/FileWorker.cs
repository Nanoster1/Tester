using Algorithms.SecondTask;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algorithms.FirstTask.SecondTask
{
    public static class FileWorker
    {
        private static Queue<object> Args { get; set; } = new Queue<object>();
        private static Queue<Operations> OperationsQueue { get; set; } = new Queue<Operations>();
        public static (Queue<Operations>, Queue<object>) ParseFile()
        {
            string[] file = File.ReadAllText(Environment.CurrentDirectory + "\\input.txt").Split(" ");
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("1"))
                {
                    string[] push = file[i].Split(",");
                    OperationsQueue.Enqueue((Operations) int.Parse(push[0]));
                    Args.Enqueue(push[1]);
                }
                else
                {
                    OperationsQueue.Enqueue((Operations)int.Parse(file[i]));
                }
            }
            return (OperationsQueue, Args);
        }
    }
}
