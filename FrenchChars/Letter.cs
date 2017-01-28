using System.Windows;

namespace FrenchChars
{
    internal class Letter
    {
        public Letter(char character) : this (character, true)
        {
        }

        public Letter(char character, bool isCommon)
        {
            Character = character;
            IsCommon = isCommon;
        }

        public char Character { get; private set; }

        public bool IsCommon { get; private set; }

        public override string ToString()
        {
            return Character.ToString();
        }

        public void SendToClipboard()
        {
            Clipboard.SetText(Character.ToString(), TextDataFormat.UnicodeText);
        }
    }
}
