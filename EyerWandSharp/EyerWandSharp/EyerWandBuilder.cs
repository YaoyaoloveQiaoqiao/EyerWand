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

        private IntPtr builderP;


        private EyerWandVideoTrack videoTrack;

        public EyerWandBuilder(string path, int width, int height, int fps)
        {
            builderP = eyer_wand_csharp_builder_init(path, width, height, fps);
        }

        public int addVideoTrack(EyerWandVideoTrack videoTrack)
        {
            this.videoTrack = new EyerWandVideoTrack(videoTrack);
            return 0;
        }


        public override int uninit()
        {
            return eyer_wand_csharp_builder_uninit(builderP);
        }
    }
}
