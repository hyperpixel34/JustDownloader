using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YT_Downloader
{
    public class extractor
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);
        [DllImport("kernel32.dll")]
        static extern IntPtr FindResource(IntPtr hModule, int lpName, int lpType);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);
        [DllImport("kernel32.dll")]
        static extern IntPtr LockResource(IntPtr hResData);
        [DllImport("user32.dll")]
        static extern int LookupIconIdFromDirectoryEx(byte[] presbits, bool fIcon, int cxDesired, int cyDesired, uint Flags);
        [DllImport("user32.dll")]
        static extern IntPtr CreateIconFromResourceEx(byte[] pbIconBits, uint cbIconBits, bool fIcon, uint dwVersion, int cxDesired, int cyDesired, uint uFlags);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

        const int RT_GROUP_ICON = 14;
        const int RT_ICON = 0x00000003;

        public static System.Drawing.Icon GetIconFromGroup(string file, int groupId, int size)
        {
            IntPtr hExe = LoadLibrary(file);
            if (hExe != IntPtr.Zero)
            {

                IntPtr hResource = FindResource(hExe, groupId, RT_GROUP_ICON);

                IntPtr hMem = LoadResource(hExe, hResource);

                IntPtr lpResourcePtr = LockResource(hMem);
                uint sz = SizeofResource(hExe, hResource);
                byte[] lpResource = new byte[sz];
                Marshal.Copy(lpResourcePtr, lpResource, 0, (int)sz);

                int nID = LookupIconIdFromDirectoryEx(lpResource, true, size, size, 0x0000);

                hResource = FindResource(hExe, nID, RT_ICON);

                hMem = LoadResource(hExe, hResource);

                lpResourcePtr = LockResource(hMem);
                sz = SizeofResource(hExe, hResource);
                lpResource = new byte[sz];
                Marshal.Copy(lpResourcePtr, lpResource, 0, (int)sz);

                IntPtr hIcon = CreateIconFromResourceEx(lpResource, sz, true, 0x00030000, size, size, 0);

                System.Drawing.Icon testIco = System.Drawing.Icon.FromHandle(hIcon);

                return testIco;
            }

            return null;
        }
    }
}
