using Algorithms.SecondTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Algorithms.FirstTask.SecondTask
{
    public class CommandsManger
    {
        public static CommandsManger Instance = new();

        public Dictionary<string, ICommandStruct<object>> Variables { get; } = new(); 
        
        public async Task<List<CommandsElement<object>>> ParseTextAsync(string[] text)
        {
            return await Task.Run(() => ParseText(text));
        }
        public List<CommandsElement<object>> ParseText(string[] text)
        { //Queue1: 1,24 3 5 3 2 1,star 5;
            var result = new List<CommandsElement<object>>();
            var tasks = string.Join("", text).Split(';').Where(x => x != "");
            foreach (var task in tasks)
            {
                var parts = task.Split(':');
                var name = parts[0];
                var commands = parts[1].Trim().Split(' ');
                var operations = new List<string>();
                var args = new System.Collections.Generic.Queue<object>();
                foreach (var command in commands)
                {
                    var commandParts = command.Split(',');
                    if (commandParts[0] == "1" )
                        args.Enqueue(
                            int.TryParse(commandParts[1], out var num) ? num : commandParts[1]
                            );
                    operations.Add(((Operations)int.Parse(commandParts[0])).ToString());
                }
                var element = new CommandsElement<object>()
                {
                    Name = name.Trim(new char[] { ' ', '\n' }),
                    Arguments = args,
                    Operations = operations
                };
                result.Add(element);
            }

            return result;
        }

        public async Task<List<object>> ActivateCommandsAsync(List<CommandsElement<object>> commandsElements)
        {
            return await Task.Run(() => ActivateCommands(commandsElements));
        }

        public List<object> ActivateCommands(List<CommandsElement<object>> commandsElements)
        {
            var results = new List<object>();
            foreach (var element in commandsElements)
            {
                var currentStruct = Variables[element.Name];
                foreach (var operation in element.Operations)
                {
                    var op = currentStruct.GetType().GetMethod(operation + "Command");
                    if (op is null) throw new NullReferenceException();
                    var paramsCount = op.GetParameters().Length;
                    var parameters = new List<object>();
                    for (int i = 0; i < paramsCount; i++)
                    {
                      parameters.Add(element.Arguments.Dequeue());  
                    }

                    var result = op.Invoke(currentStruct, parameters.ToArray());
                    if (result != null) results.Add(result);
                }
            }

            return results;
        }
    }
}
