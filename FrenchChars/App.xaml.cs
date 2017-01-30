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
        private readonly ClipboardHandler _clipboard = new ClipboardHandler(new Letters());

        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();
                application.InitializeComponent();

                new LetterJumpList()
                    .Create()
                    .Apply();

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
                _clipboard.Copy(e.Args[0]);

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
                _clipboard.Copy(args[1]);
            }

            return true;
        }

    }
}
