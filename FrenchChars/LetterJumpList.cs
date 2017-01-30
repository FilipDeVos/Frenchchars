using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Shell;

namespace FrenchChars
{
    internal class LetterJumpList
    {
        private readonly Assembly _applicationAssembly;
        private readonly Application _application;

        public LetterJumpList() : this(Application.Current)
        {
            _applicationAssembly = GetApplication();
        }

        public LetterJumpList(Application application)
        {
            _application = application;
        }

        public JumpList Create()
        {
            JumpList jumpList = new JumpList();
            JumpList.SetJumpList(_application, jumpList);
            jumpList.JumpItems.AddRange(GetJumpTasks(new Letters().Select(x=>x.Value).Where(y => y.IsCommon)));
            jumpList.JumpItems.Add(GetClearFormattingTask());
            return jumpList;
        }

        internal IEnumerable<JumpTask> GetJumpTasks(IEnumerable<Letter> letters)
        {
            foreach (var letter in letters)
            {
                yield return new JumpTask
                {
                    Title = $"Copy {letter}...",
                    Description = $"Copy the letter {letter} to the clipboard.",
                    ApplicationPath = _applicationAssembly.Location,
                    Arguments = $"{letter}",
                    IconResourcePath = _applicationAssembly.Location,
                    IconResourceIndex = -1
                };
            }
        }

        internal JumpTask GetClearFormattingTask()
        {
            return new JumpTask
            {
                Title = $"Clear Formatting...",
                Description = $"Clear the formatting from the text on the clipboard.",
                ApplicationPath = _applicationAssembly.Location,
                Arguments = $"clear",
                IconResourcePath = _applicationAssembly.Location,
                IconResourceIndex = -1
            };
        }

        internal static Assembly GetApplication() {
            return (AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(item => item.EntryPoint != null)
                    .Select(item => new { item, applicationType = item.GetType(item.GetName().Name + ".App", false) })
                    .Where(a => a.applicationType != null && typeof(System.Windows.Application).IsAssignableFrom(a.applicationType))
                    .Select(a => a.item))
                    .FirstOrDefault();
        }
    }
}
