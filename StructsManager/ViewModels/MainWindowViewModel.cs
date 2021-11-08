using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using StructsManager.Models;
using StructsConsole;
using System.Threading.Tasks;
using System.IO;

namespace StructsManager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int variableIndex = 0;
        private CommandsManager _commandsManager = CommandsManager.Instance;

        public MainWindowViewModel()
        {
            Variables.CollectionChanged += Variables_CollectionChanged;
            ConsoleCommand = ReactiveCommand.CreateFromTask(ExecuteConsole, this.WhenAnyValue(x => x.ConsoleText, ct => !string.IsNullOrWhiteSpace(ct)));
            CreateVariableCommand = ReactiveCommand.CreateFromTask(CreateVariable, this.WhenAnyValue(x => x.SelectedType, (Type st) => st != null));
        }

        private void Variables_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var newItems = new Dictionary<string, object>();
            for (int i = 0; i < e.NewItems.Count; i++)
            {
                var item = (Variable)e.NewItems[i];
                if (_commandsManager.Variables.ContainsKey(item.Name)) continue;
                _commandsManager.Variables.Add(item.Name, item.Data);
            }
        }

        [Reactive] public ObservableCollection<Variable> Variables { get; set; } = new();
        [Reactive] public ObservableCollection<AssemblyModel> Assemblies { get; set; } = new() { new AssemblyModel(Assembly.GetExecutingAssembly()) };
        [Reactive] public Type SelectedType { get; set; }
        [Reactive] public string ResultText { get; set; }
        [Reactive] public string ConsoleText { get; set; }

        public ReactiveCommand<Unit, Unit> ConsoleCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CreateVariableCommand { get; set; }

        public Interaction<Unit, string> LoadAsInteraction { get; } = new();
        public Interaction<Exception, Unit> GetException { get; } = new();
        public Interaction<string, string> SetVariableName { get; } = new();

        public event Action<string> ConsoleTextChanged = (s) => { };

        public async void LoadFile()
        {
            var path = await LoadAsInteraction.Handle(Unit.Default);
            if (string.IsNullOrWhiteSpace(path)) return;
            var text = await File.ReadAllLinesAsync(path);
            ConsoleText = string.Join('\n', text);
            ConsoleTextChanged(ConsoleText);
        }

        public async void LoadSystem(bool value)
        {
            if (value) Assemblies.Add(new AssemblyModel(Assembly.GetAssembly(typeof(int))));
            else Assemblies.Remove(Assemblies.First(x => x.Name.Contains("System")));
        }

        public async void LoadAssembly()
        {
            var path = await LoadAsInteraction.Handle(Unit.Default);
            if (!string.IsNullOrWhiteSpace(path))
                Assemblies.Add(new(Assembly.LoadFrom(path)));
        }

        public async Task ExecuteConsole()
        {
            try
            {
                ConsoleText = string.Concat(ConsoleText.Where(x => !char.IsControl(x)));
                var code = await _commandsManager.ParseTextAsync(new string[] { ConsoleText });
                var results = await _commandsManager.ActivateCommandsAsync(code);
                ResultText = string.Join('\n', results.Select(x => $"{x.CommandName}: {x.Result}"));
            }
            catch(Exception ex)
            {
                ResultText = ex.ToString();
            }
        }

        public async Task CreateVariable()
        {
            var varName = await SetVariableName.Handle(SelectedType.Name);
            if (varName == null) return;

            object instance;
            try
            {
                if (SelectedType.IsGenericType)
                {
                    Type[] args = new Type[SelectedType.GetGenericArguments().Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = typeof(object);
                    }
                    instance = Activator.CreateInstance(SelectedType.MakeGenericType(args));
                }
                else
                {
                    instance = Activator.CreateInstance(SelectedType);
                }
            }
            catch
            {
                instance = SelectedType;
            }

            var variable = new Variable()
            {
                Name = varName,
                Data = instance
            };
            Variables.Add(variable);
        }
    }
}
