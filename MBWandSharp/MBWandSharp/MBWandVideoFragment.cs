using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBWandSharp
{
    public class MBWandVideoFragment
    {
        [DllImport("libMBWand.dll")]
        private extern static IntPtr mb_csharp_fragment_init(string _out_path);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_fragment_uninit(IntPtr fragment);

        public IntPtr fragment;

        public MBWandVideoFragment(string _out_path)
        {
            this.fragment = mb_csharp_fragment_init(_out_path);
        }

        public int uninit()
        {
            return mb_csharp_fragment_uninit(this.fragment);
        }
    }
}
