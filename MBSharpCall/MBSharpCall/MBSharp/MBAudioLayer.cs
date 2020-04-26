using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBAudioLayer
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_audio_layer_init(double _startTime, double _endTime);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_layer_uninit(IntPtr layer);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_layer_add_fragment(IntPtr layer, IntPtr fragment);

        public IntPtr audioLayer;
        public MBAudioLayer(double _startTime, double _endTime)
        {
            this.audioLayer = mb_csharp_audio_layer_init(_startTime, _endTime);
        }

        public int addFragment(IntPtr fragment)
        {
            return mb_csharp_audio_layer_add_fragment(this.audioLayer, fragment);
        }

        public int uninit()
        {
            return mb_csharp_audio_layer_uninit(this.audioLayer);
        }
    }
}
