using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructsConsole
{
    public partial class CommandsManager
    {
        public async Task<List<CommandResult>> ActivateCommandsAsync(List<CommandsElement> commandsElements) => 
            await Task.Run(() => ActivateCommands(commandsElements));

        private CommandResult ActivateOneCommand(CommandsElement commandsElement) => 
            ActivateCommands(new List<CommandsElement>() {commandsElement}).First();

        public List<CommandResult> ActivateCommands(List<CommandsElement> commandsElements)
        {
            var results = new List<CommandResult>();
            foreach (var element in commandsElements)
            {
                object result;
                var currentStruct = Variables[element.Name];
                foreach (var operation in element.Operations)
                {
                    var type = (currentStruct as Type) ?? currentStruct.GetType();
                    var op = type.GetMethod(operation) ?? type.GetProperty(operation)?.GetMethod;

                    if (op is null)
                    {
                        result = type.GetField(operation)?.GetValue(currentStruct) ?? throw new NullReferenceException();
                    }
                    else
                    {
                        var parameters = op.GetParameters();
                        var paramsCount = parameters.Length;
                        var finalParameters = new List<object>();
                        for (var i = 0; i < paramsCount; i++)
                        {
                            var parameter = element.Arguments.Dequeue();
                            if (parameter is CommandsElement commandsElement)
                            {
                                parameter = ActivateOneCommand(commandsElement).Result;
                            }

                            finalParameters.Add(parameter);
                        }

                        result = op.Invoke(currentStruct, finalParameters.ToArray());
                    }

                    if (result != null)
                    {
                        results.Add(new CommandResult(operation, result));
                    }
                }
            }
            return results;
        }
    }
}