using Microsoft.Shell;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FrenchChars
{
    public partial class App : Application, ISingleInstanceApp
    {
        private const string Unique = "FrenchChars_ff18379c-ab4b-4b14-b1a6-372c3242ee94";
        private static readonly Letters _letters = new Letters();

        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();
                application.InitializeComponent();
                new LetterJumpList().Create();
                application.Run();
                SingleInstance<App>.Cleanup();

                using (var mgr = new UpdateManager(@".\Releases"))
                {
                    mgr.UpdateApp();
                }
            }
        }

        /// <summary>
        /// This event is required for handling cold starts with a parameter.
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args != null && e.Args.Count() >= 1)
            {
                CopyToClipboard(e.Args[0]);

                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }

        /// <summary>
        /// This event is required to handle warm starts with parameters
        /// </summary>
        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            if (args == null || args.Count <= 1)
            {
                if (this.MainWindow.WindowState == WindowState.Minimized)
                {
                    this.MainWindow.WindowState = WindowState.Normal;
                }

                this.MainWindow.Activate();
            }
            else
            {
                CopyToClipboard(args[1]);
            }

            return true;
        }

        private static void CopyToClipboard(string argument)
        {
            if (argument.Length > 1)
            {
                var text = Clipboard.GetData(DataFormats.Text) as string;
                Clipboard.SetText(text);
            }
            else
            {
                _letters[argument]?.SendToClipboard();
            }
        }
    }
}
