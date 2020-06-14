using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace EyerWandSharp
{
    public class EyerWandBuilder : EyerWand
    {
        [DllImport("libEyerWand.dll")]
        private extern static IntPtr eyer_wand_csharp_builder_init(string out_path, int width, int height, int fps);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_builder_uninit(IntPtr builderP);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_builder_process(IntPtr builderP);

        [DllImport("libEyerWand.dll")]
        private extern static int eyer_wand_csharp_builder_add_video_track(IntPtr builderP, IntPtr videoTrackP);
        
        private IntPtr builderP;


        private EyerWandVideoTrack videoTrack;

        public EyerWandBuilder(string path, int width, int height, int fps)
        {
            builderP = eyer_wand_csharp_builder_init(path, width, height, fps);
        }

        public int addVideoTrack(IntPtr videoTrack)
        {
            //todo EyerWandVideoTrack（videoTrack）对象拷贝
            //this.videoTrack = new EyerWandVideoTrack(videoTrack);
            eyer_wand_csharp_builder_add_video_track(this.builderP, videoTrack);
            return 0;
        }

        public int process()
        {
            return eyer_wand_csharp_builder_process(builderP);
        }


        public override int uninit()
        {
            return eyer_wand_csharp_builder_uninit(builderP);
        }
    }
}
