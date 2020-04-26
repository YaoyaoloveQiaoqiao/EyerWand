using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBVideoFragmentFrameSequential
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_frame_sequence_fragment_init(string _out_path, int fileNum, int model);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_frame_sequence_fragment_uninit(IntPtr _fragment);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_frame_sequence_fragment_scale(IntPtr _fragment, float x, float y, float z);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_frame_sequence_fragment_trans(IntPtr _fragment, float x, float y, float z);

        public IntPtr fragment;

        public MBVideoFragmentFrameSequential(string _out_path,int model)
        {
            //根据路径获取png文件数
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(_out_path);
            int fileNum = dirInfo.GetFiles("*.png").Length;
            Console.WriteLine("-------------fileNum:"+ fileNum);
            this.fragment = mb_csharp_frame_sequence_fragment_init(_out_path, fileNum, model);
        }

        public int addTrans(float x, float y, float z)
        {
            return mb_csharp_frame_sequence_fragment_trans(this.fragment, x, y, z);
        }

        public int addScale(float x, float y, float z)
        {
            return mb_csharp_frame_sequence_fragment_scale(this.fragment, x, y, z);
        }
     
        public int uninit()
        {
            return mb_csharp_frame_sequence_fragment_uninit(this.fragment);
        }
    }
}

