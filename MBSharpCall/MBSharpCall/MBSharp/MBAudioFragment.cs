using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBAudioFragment
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_audio_fragment_init(string _out_path);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_fragment_uninit(IntPtr fragment);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_audio_fragment_set_weight(IntPtr fragment, float weight);
        
        public IntPtr audioFragment;

        public MBAudioFragment(string path)
        {
            this.audioFragment = mb_csharp_audio_fragment_init(path);
        }

        public int uninit()
        {
            return mb_csharp_audio_fragment_uninit(this.audioFragment);
        }

        public int setWeight(float weight)
        {
            return mb_csharp_audio_fragment_set_weight(this.audioFragment, weight);
        }
    }
}
