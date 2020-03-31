using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBWandSharp
{
    public class MBWandVideoLayer
    {
        [DllImport("libMBWand.dll")]
        private extern static IntPtr mb_csharp_layer_init(int _startFrameIndex, int _endFrameIndex);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_layer_uninit(IntPtr layer);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_layer_add_fragment(IntPtr layer, IntPtr fragment);

        public IntPtr layer;
        public MBWandVideoLayer(int _startFrameIndex, int _endFrameIndex)
        {
            this.layer = mb_csharp_layer_init(_startFrameIndex, _endFrameIndex);
        }

        public int addFragment(IntPtr fragment)
        {
            return mb_csharp_layer_add_fragment(this.layer, fragment);
        }

        public int uninit()
        {
            return mb_csharp_layer_uninit(this.layer);
        }
    }
}
