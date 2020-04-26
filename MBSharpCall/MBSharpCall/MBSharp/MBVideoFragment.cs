using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBVideoFragment
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_fragment_init(string _out_path);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_fragment_uninit(IntPtr fragment);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_fragment_add_transkey(IntPtr _fragment, double t, float x, float y, float z);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_fragment_add_scalekey(IntPtr _fragment, double t, float x, float y, float z);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_fragment_add_filter(IntPtr _fragment, double t, int filterId, int level);

        public IntPtr fragment;

        public MBVideoFragment(string _out_path)
        {
            this.fragment = mb_csharp_fragment_init(_out_path);
        }

        public int addTransKey(double t, float x, float y, float z)
        {
            return mb_csharp_fragment_add_transkey(this.fragment, t, x, y, z);
        }

        public int addScaleKey(double t, float x, float y, float z)
        {
            return mb_csharp_fragment_add_scalekey(this.fragment, t, x, y, z);
        }
        public int addFilter(double t, int filterId, int level)
        {
            return mb_csharp_fragment_add_filter(this.fragment, t, filterId, level);
        }
        public int uninit()
        {
            return mb_csharp_fragment_uninit(this.fragment);
        }
    }
}
