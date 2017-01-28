using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FrenchChars.Tests
{
    [TestFixture]
    public class LettersTests
    {
        [Test]
        public void LettersShouldContainItems()
        {
            var x = new Letters();

            var result = x.Any();

            Assert.That(result, Is.True);
        }

        [Test]
        public void LettersShouldNotContainNormalChars()
        {
            var letters = new Letters();

            var result = letters.Where(x =>
            {
                var ascii = (int)x.Value.Character;
                return ascii >= 97 && ascii <= 122;
            });

            Assert.That(result.Count(), Is.Zero);
        }

        [Test]
        public void LettersShouldNotContainUppercase()
        {
            var letters = new Letters();

            var result = letters.Where(x => x.Value.ToString() == x.Value.ToString().ToUpperInvariant());

            Assert.That(result.Count(), Is.Zero);
        }
    }
}
