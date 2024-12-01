using System;
using System.Windows.Forms;
using Windows_Forms_CORE_CHAT_UGH;

namespace Windows_Forms_Chat
{
    static class Program
    {
        /*
            This is the main entry point for the program. It initially calls the
            'ConnectionForm' which in turn will call the 'ChatForm' if login is successful.
        */
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
