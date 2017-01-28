using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrenchChars
{
    public class CopyCommand : ICommand
    {
        // Singleton for the simple cases, may be replaced with your own factory if needed.
        static CopyCommand()
        {
            Instance = new CopyCommand();
        }
        public static ICommand Instance { get; private set; }

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
