using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MBWandSharp
{
    public abstract class MBWand
    {
        [DllImport("libMBWand.dll")]
        public extern static int mb_csharp_get_version(ref byte str_buf);

        public static string getVersion()
        {
            Byte[] strBuffer = new Byte[128];

            int ret = mb_csharp_get_version(ref strBuffer[0]);
            if (ret != 0)
            {
                return "Get Version Error";
            }

            string versionStr = System.Text.Encoding.Default.GetString(strBuffer, 0, strBuffer.Length);

            return versionStr;
        }

        public abstract int uninit();
    }
}
