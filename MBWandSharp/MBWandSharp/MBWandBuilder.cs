using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBWandSharp
{
    public class MBWandBuilder : MBWand
    {
        [DllImport("libMBWand.dll")]
        private extern static IntPtr mb_csharp_builder_init(string out_path, int width, int height, int fps);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_builder_uninit(IntPtr builderP);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_builder_process(IntPtr builderP);

        [DllImport("libMBWand.dll")]
        private extern static int mb_csharp_builder_add_video_track(IntPtr builderP, IntPtr videoTrackP);
        
        private IntPtr builderP;


        private MBWandVideoTrack videoTrack;

        public MBWandBuilder(string path, int width, int height, int fps)
        {
            builderP = mb_csharp_builder_init(path, width, height, fps);
        }

        public int addVideoTrack(IntPtr videoTrack)
        {
            //todo MBWandVideoTrack（videoTrack）对象拷贝
            //this.videoTrack = new MBWandVideoTrack(videoTrack);
            mb_csharp_builder_add_video_track(this.builderP, videoTrack);
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
