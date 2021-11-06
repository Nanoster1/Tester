#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StructsConsole
{
    public partial class CommandsManager
    {
        public static readonly CommandsManager Instance = new();

        public Dictionary<string, object> Variables { get; } = new();
        
        /*public List<CommandsElement> ParseText(string[] text)
        {
            //Queue1: Add(24) Peek() Print() Peek() Remove() Add(star) Print();
            var result = new List<CommandsElement>();
            var tasks = string.Join(' ', text).Split(';').Where(x => !string.IsNullOrEmpty(x));
            foreach (var task in tasks)
            {
                var parts = task.Split(':');
                var name = parts[0];
                var commands = parts[1].Trim().Split(' ');
                var operations = new List<string>();
                var args = new System.Collections.Generic.Queue<object>();
                foreach (var command in commands)
                {
                    if (command.Contains('('))
                    {
                        var commandParts = command.Split('(');
                        var commandArgs = commandParts[1].Remove(commandParts[1].Length - 1).Split(',');
                        foreach (var arg in commandArgs)
                        {
                            if (string.IsNullOrWhiteSpace(arg)) break;
                            else if (arg[0] is '\'' or '\"' && arg[^1] is '\'' or '\"') args.Enqueue(arg.Replace("\'", string.Empty));
                            else if (byte.TryParse(arg, out var numInt16)) args.Enqueue(numInt16);
                            else if (int.TryParse(arg, out var numInt32)) args.Enqueue(numInt32);
                            else if (double.TryParse(arg, out var numDouble)) args.Enqueue(numDouble);
                            else if (bool.TryParse(arg, out var valueB)) args.Enqueue(valueB);
                            /*else if (arg == "default") args.Enqueue(arg);#1#
                            /*else if (arg.Contains("new/")) args.Enqueue(ChooseNewVar(arg.Split('/')[1]));#1#
                            else args.Enqueue(Variables[arg]);
                        }

                        operations.Add(commandParts[0]);
                    }
                    else operations.Add(command);
                }

                var element = new CommandsElement()
                {
                    Name = name.Trim(new char[] {' ', '\n'}),
                    Arguments = args,
                    Operations = operations
                };
                result.Add(element);
            }

            return result;
        }*/
    }
}