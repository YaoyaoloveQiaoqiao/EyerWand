using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBAudioTrack
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_audio_track_init();

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_track_uninit(IntPtr audioTrackP);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_track_add_layer(IntPtr audioTrackP, IntPtr layer);

        public IntPtr audioTrackP;
        public MBAudioTrack()
        {
            this.audioTrackP = mb_csharp_audio_track_init();
        }

        public int addLayer(IntPtr layer)
        {
            return mb_csharp_audio_track_add_layer(this.audioTrackP, layer);
        }
        public int uninit()
        {
            return mb_csharp_audio_track_uninit(this.audioTrackP);
        }
    }
}
