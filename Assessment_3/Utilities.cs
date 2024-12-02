using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public static class Utilities
    {
        // Extension method for thread-safe UI updates
        public static void SafeInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                // If not on the UI thread, marshal the call to the UI thread
                control.Invoke(action);
            }
            else
            {
                // If already on the UI thread, just execute the action
                action();
            }
        }
    }
}
