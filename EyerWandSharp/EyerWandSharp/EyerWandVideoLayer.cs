using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace EyerWandSharp
{
    public class EyerWandVideoLayer
    {
        [DllImport("libEyerWand.dll")]
        private extern static IntPtr eyer_wand_csharp_layer_init(int _startFrameIndex, int _endFrameIndex);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_layer_uninit(IntPtr layer);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_layer_add_fragment(IntPtr layer, IntPtr fragment);

        public IntPtr layer;
        public EyerWandVideoLayer(int _startFrameIndex, int _endFrameIndex)
        {
            this.layer = eyer_wand_csharp_layer_init(_startFrameIndex, _endFrameIndex);
        }

        public int addFragment(IntPtr fragment)
        {
            return eyer_wand_csharp_layer_add_fragment(this.layer, fragment);
        }

        public int uninit()
        {
            return eyer_wand_csharp_layer_uninit(this.layer);
        }
    }
}
