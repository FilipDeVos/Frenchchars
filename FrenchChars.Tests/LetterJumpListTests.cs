using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Windows.Shell;

namespace FrenchChars.Tests
{
    [TestFixture]
    public class LetterJumpListTests
    {
        [Test]
        [Category("integration")]
        public void GetApplicationShouldReturnAnExe()
        {
            var result = LetterJumpList.GetApplication();

            Assert.That(result.GetFiles().First().Name, Does.EndWith("exe"));
        }

        [Test]
        public void GetClearFormattingTaskShouldHaveArgumentsClear()
        {
            var list = new LetterJumpList();
            var result = list.GetClearFormattingTask();
            Assert.That(result.Arguments, Is.EqualTo("clear"));
        }

        [Test]
        public void GetJumpTasksShouldReturnTasksForEachLetter()
        {
            var list = new LetterJumpList();
            var result = list.GetJumpTasks(new[] { new Letter('a'), new Letter('b')});
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetJumpTasksShouldReturnTasksForEachLetterWithTheLetterInTheLabel()
        {
            var list = new LetterJumpList();
            var letter = new Letter('a');
            var result = list.GetJumpTasks(new[] { letter });
            Assert.That(result.First().Title, Does.Contain(letter.ToString()));
        }
    }
}
