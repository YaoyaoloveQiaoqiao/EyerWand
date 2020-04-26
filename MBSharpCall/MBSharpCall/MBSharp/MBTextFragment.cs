using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MBSharp
{
    public class MBTextFragment
    {
        [DllImport("libMB.dll")]
        private extern static IntPtr mb_csharp_text_fragment_init(string _out_path, ref byte text);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_text_fragment_uninit(IntPtr fragment);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_text_fragment_style(IntPtr _text_fragment, int size, float x, float y, float r, float g, float b, int video_width);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_text_fragment_width(IntPtr fragment);

        [DllImport("libMB.dll")]
        private extern static int mb_csharp_text_fragment_size(IntPtr fragment, int size);
                 
        public IntPtr textFragment;
        private string textContent;
        private string path;

        public MBTextFragment(string _out_path,string text)
        {
            textContent = text;
            path = _out_path;
            byte[] tByte = Encoding.UTF8.GetBytes(text);
            this.textFragment = mb_csharp_text_fragment_init(_out_path, ref tByte[0]);
        }

        public int uninit()
        {
            return mb_csharp_text_fragment_uninit(this.textFragment);
        }

        public int set_text_style(int size, float x, float y, float r, float g, float b, int video_width)
        {
            return mb_csharp_text_fragment_style(this.textFragment, size, x, y, r, g, b, video_width);
        }

        public int setSize(int size)
        {
            return mb_csharp_text_fragment_size(this.textFragment, size);
        }

        public int getTextWidth()
        {
            return mb_csharp_text_fragment_width(this.textFragment);
        }

        //居中逐个字显示字幕
        public int showOneByOne(float startTime, float endTime, float speed, int pts, MBVideoTrack videoTrack, int size, float x, float y, float r, float g, float b, int video_width)
        {
            setSize(size);
            int textWith = getTextWidth();
            float textMiddleLeft = 1280 / 2 - textWith / 2;
            MBVideoLayer textLayer;
            for (int i=0; i< textContent.Length; i++){
                if(i == textContent.Length - 1)
                {
                    textLayer = new MBVideoLayer((int)(i * speed * pts + startTime), (int)endTime);
                }
                else
                {
                    textLayer = new MBVideoLayer((int)(i * speed * pts + startTime), (int)((i + 1) * speed * pts + startTime));
                }
                MBTextFragment textFragement1 = new MBTextFragment(path, textContent.Substring(0, i+1));
                //设置文字样式，size: 大小；x: x轴位置； y: y轴位置; r: 颜色R值；g: 颜色G值；b: 颜色B值； 
                textFragement1.set_text_style(size, textMiddleLeft, y, r, g, b, video_width);
                textLayer.addTextFragment(textFragement1.textFragment);
                videoTrack.addLayer(textLayer.layer);
                textFragement1.uninit();
                textLayer.uninit();
            }

            return 0;
        }
    }
}
