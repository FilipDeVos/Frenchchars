using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FrenchChars
{
    internal class Letters : IReadOnlyDictionary<string, Letter>
    {
        private readonly Dictionary<string, Letter> _letters;
        public Letters()
        {
            _letters = GetLetters();
        }

        public Letter this[string key]
        {
            get
            {
                return _letters[key];
            }
        }

        public int Count
        {
            get
            {
                return _letters.Count;
            }
        }

        public IEnumerable<string> Keys
        {
            get
            {
                return ((IReadOnlyDictionary<string, Letter>)_letters).Keys;
            }
        }

        public IEnumerable<Letter> Values
        {
            get
            {
                return ((IReadOnlyDictionary<string, Letter>)_letters).Values;
            }
        }

        private static Dictionary<string, Letter> GetLetters()
        {
            var dictionary = new Dictionary<string, Letter>();
            dictionary.Add("á", new Letter('á'));
            dictionary.Add("â", new Letter('â'));
            dictionary.Add("ä", new Letter('ä', false));
            dictionary.Add("æ", new Letter('æ', false));

            dictionary.Add("ç", new Letter('ç'));

            dictionary.Add("é", new Letter('é'));
            dictionary.Add("è", new Letter('è'));
            dictionary.Add("ê", new Letter('ê'));
            dictionary.Add("ë", new Letter('ë'));

            dictionary.Add("î", new Letter('î'));
            dictionary.Add("ï", new Letter('ï', false));

            dictionary.Add("ô", new Letter('ô'));
            dictionary.Add("œ", new Letter('œ', false));

            dictionary.Add("ù", new Letter('ù'));
            dictionary.Add("û", new Letter('û'));
            dictionary.Add("ü", new Letter('ü', false));
            return dictionary;
        }

        public bool ContainsKey(string key)
        {
            return _letters.ContainsKey(key);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IReadOnlyDictionary<string, Letter>)_letters).GetEnumerator();
        }

        public bool TryGetValue(string key, out Letter value)
        {
            return _letters.TryGetValue(key, out value);
        }

        IEnumerator<KeyValuePair<string, Letter>> IEnumerable<KeyValuePair<string, Letter>>.GetEnumerator()
        {
            return _letters.GetEnumerator();
        }
    }
}
