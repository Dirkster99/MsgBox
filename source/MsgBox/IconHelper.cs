namespace MsgBox
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;

    /// <summary>
    /// Remove an icon from a window's (system style) title bar:
    /// Source: http://wpftutorial.net/RemoveIcon.html
    /// </summary>
    public static class IconHelper
    {
        private const int GwlEXSTYLE = -20;
        private const int WsExDLGMODALFRAME = 0x0001;
        private const int SwpNOSIZE = 0x0001;
        private const int SwpNOMOVE = 0x0002;
        private const int SwpNOZORDER = 0x0004;
        private const int SwpFRAMECHANGED = 0x0020;
        private const uint WmSETICON = 0x0080;

        /// <summary>
        /// Call this function from a dialog view to remove a displayed icon from the dialog title bar.
        /// </summary>
        /// <param name="window"></param>
        public static void RemoveIcon(Window window)
        {
            // Get this window's handle
            IntPtr hwnd = new WindowInteropHelper(window).Handle;

            // Change the extended window style to not show a window icon
            int extendedStyle = NativeMethods.GetWindowLong(hwnd, GwlEXSTYLE);
            NativeMethods.SetWindowLong(hwnd, GwlEXSTYLE, extendedStyle | WsExDLGMODALFRAME);

            // Update the window's non-client area to reflect the changes
            NativeMethods.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SwpNOMOVE |
                                             SwpNOSIZE | SwpNOZORDER | SwpFRAMECHANGED);
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern int GetWindowLong(IntPtr hwnd, int index);

            [DllImport("user32.dll")]
            internal static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

            [DllImport("user32.dll")]
            internal static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                                                    int x, int y, int width, int height, uint flags);

            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hwnd, uint msg,
                                    IntPtr wParam, IntPtr lParam);
        }
    }
}
