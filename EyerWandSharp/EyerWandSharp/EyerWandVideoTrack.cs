using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace EyerWandSharp
{
    public class EyerWandVideoTrack
    {
        [DllImport("libEyerWand.dll")]
        private extern static IntPtr eyer_wand_csharp_video_track_init();

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_video_track_uninit(IntPtr videoTrackP);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_video_track_add_layer(IntPtr videoTrackP, IntPtr layer);

        public IntPtr videoTrackP;
        public EyerWandVideoTrack()
        {
            this.videoTrackP = eyer_wand_csharp_video_track_init();
        }

        public EyerWandVideoTrack(EyerWandVideoTrack videoTrack)
        {

        }

        public int addLayer(IntPtr layer)
        {
            return eyer_wand_csharp_video_track_add_layer(this.videoTrackP, layer);
        }
        public int uninit()
        {
            return eyer_wand_csharp_video_track_uninit(this.videoTrackP);
        }
    }
}
