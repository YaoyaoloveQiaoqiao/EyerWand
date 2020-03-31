using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBWandSharp
{
    public class MBWandVideoTrack
    {
        [DllImport("libMBWand.dll")]
        private extern static IntPtr mb_csharp_video_track_init();

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_video_track_uninit(IntPtr videoTrackP);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_video_track_add_layer(IntPtr videoTrackP, IntPtr layer);

        public IntPtr videoTrackP;
        public MBWandVideoTrack()
        {
            this.videoTrackP = mb_csharp_video_track_init();
        }

        public MBWandVideoTrack(MBWandVideoTrack videoTrack)
        {

        }

        public int addLayer(IntPtr layer)
        {
            return mb_csharp_video_track_add_layer(this.videoTrackP, layer);
        }
        public int uninit()
        {
            return mb_csharp_video_track_uninit(this.videoTrackP);
        }
    }
}
