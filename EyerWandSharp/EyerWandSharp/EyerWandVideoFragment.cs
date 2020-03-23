using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace EyerWandSharp
{
    public class EyerWandVideoFragment
    {
        [DllImport("libEyerWand.dll")]
        private extern static IntPtr eyer_wand_csharp_fragment_init(string _out_path);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_fragment_uninit(IntPtr fragment);

        public IntPtr fragment;

        public EyerWandVideoFragment(string _out_path)
        {
            this.fragment = eyer_wand_csharp_fragment_init(_out_path);
        }

        public int uninit()
        {
            return eyer_wand_csharp_fragment_uninit(this.fragment);
        }
    }
}
