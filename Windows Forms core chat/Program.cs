using System;
using System.Windows.Forms;
using Windows_Forms_CORE_CHAT_UGH;

namespace Windows_Forms_Chat
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionForm());
        }
    }
}
