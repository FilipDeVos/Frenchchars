using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrenchChars
{
    internal class ClipboardHandler
    {
        private readonly Letters _letters;

        public ClipboardHandler(Letters letters)
        {
            _letters = letters;
        }

        public void Copy(string argument)
        {
            if (argument.Length > 1)
            {
                var text = Clipboard.GetData(DataFormats.Text) as string;
                Clipboard.SetText(text);
            }
            else
            {
                if (null == _letters) throw new ArgumentNullException(nameof(_letters), "Letters collection is empty");
                _letters[argument]?.SendToClipboard();
            }
        }
    }
}
