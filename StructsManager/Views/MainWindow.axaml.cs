using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaEdit;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Highlighting.Xshd;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using StructsManager.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Xml;

namespace StructsManager.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private TextEditor _textEditor;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _textEditor = this.FindControl<TextEditor>("Editor");

            this.WhenActivated(disposables => 
            {
                LoadHighlighting(Environment.CurrentDirectory + "\\init.xml");

                ViewModel.LoadAsInteraction.RegisterHandler(async context => 
                {
                    var window = new OpenFileDialog();
                    var result = await window.ShowAsync(this) ?? Array.Empty<string>();
                    var path = result.FirstOrDefault();
                    context.SetOutput(path ?? string.Empty);
                });

                ViewModel.GetException.RegisterHandler(async context =>
                {
                    var window = MessageBoxManager.GetMessageBoxStandardWindow("ОШИБКА", $"Не удаётся создать переменную:\n{context.Input}", 
                        ButtonEnum.Ok, 
                        MessageBox.Avalonia.Enums.Icon.Error);
                    await window.ShowDialog(this);
                    context.SetOutput(Unit.Default);
                });
            });
        }

        private void TextChanged(object? sender, EventArgs e)
        {
            ViewModel.ConsoleText = this.FindControl<TextEditor>("Editor").Text;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async void LoadHighlighting(string path)
        {
            if (File.Exists(path)) 
            {
                using var xshd_stream = File.OpenRead(path);
                using var xshd_reader = new XmlTextReader(xshd_stream);
                try { _textEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd_reader, HighlightingManager.Instance); } catch { }
                return;
            }
            var window = MessageBoxManager.GetMessageBoxStandardWindow("ОШИБКА", $"Не найден файл подстветки\nХотите выбрать новый файл?",
                     ButtonEnum.YesNo,
                     MessageBox.Avalonia.Enums.Icon.Error);
            var answer = await window.ShowDialog(this);
            if (answer == ButtonResult.Yes)
            {
                var fileDialog = new OpenFileDialog();
                var result = await fileDialog.ShowAsync(this) ?? Array.Empty<string>();
                path = result.FirstOrDefault() ?? string.Empty;
                LoadHighlighting(path);
            }
            return;
        }

       /* private void MainWindow_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.InputModifiers != Avalonia.Input.InputModifiers.RightMouseButton) return;

        }*/
    }
}
