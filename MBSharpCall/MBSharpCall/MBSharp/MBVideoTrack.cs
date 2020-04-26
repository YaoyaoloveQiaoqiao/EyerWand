using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBVideoTrack
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_video_track_init();

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_video_track_uninit(IntPtr videoTrackP);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_video_track_add_layer(IntPtr videoTrackP, IntPtr layer);

        public IntPtr videoTrackP;
        public MBVideoTrack()
        {
            this.videoTrackP = mb_csharp_video_track_init();
        }

        public MBVideoTrack(MBVideoTrack videoTrack)
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
