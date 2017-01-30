using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrenchChars
{
    public class CopyCommand : ICommand
    {
        public static ICommand Instance { get; private set; } = new CopyCommand();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var button = parameter as Button;
            if (null != button)
            {
                var textBlock = button.Content as TextBlock;
                if (null != textBlock)
                {
                    Clipboard.SetText(textBlock.Text, TextDataFormat.UnicodeText);
                }
            }
        }
    }
}
