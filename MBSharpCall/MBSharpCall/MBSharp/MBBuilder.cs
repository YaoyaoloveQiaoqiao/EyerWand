using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBBuilder : MB
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_builder_init(string out_path, int width, int height, int fps);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_builder_uninit(IntPtr builderP);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_builder_process(IntPtr builderP);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_builder_add_video_track(IntPtr builderP, IntPtr videoTrackP);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_builder_add_audio_track(IntPtr builderP, IntPtr audioTrackP);
        
        private IntPtr builderP;


        private MBVideoTrack videoTrack;

        public MBBuilder(string path, int width, int height, int fps)
        {
            builderP = mb_csharp_builder_init(path, width, height, fps);
        }

        public int addVideoTrack(IntPtr videoTrack)
        {
            mb_csharp_builder_add_video_track(this.builderP, videoTrack);
            return 0;
        }
        public int addAudioTrack(IntPtr audioTrack)
        {
            mb_csharp_builder_add_audio_track(this.builderP, audioTrack);
            return 0;
        }

        public int process()
        {
            return mb_csharp_builder_process(builderP);
        }


        public override int uninit()
        {
            return mb_csharp_builder_uninit(builderP);
        }
    }
}
