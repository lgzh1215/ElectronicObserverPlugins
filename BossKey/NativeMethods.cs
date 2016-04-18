using BossKey;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BossKey
{
    internal class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint ID);
    }
}
