using System;
using EyerWandSharp;

namespace EyerWandSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EyerWand.getVersion());

            EyerWandBuilder eyerWandBuilder = new EyerWandBuilder("./test.mp4", 1280, 720, 30);

            EyerWandVideoTrack videoTrack = new EyerWandVideoTrack();





            eyerWandBuilder.addVideoTrack(videoTrack);

            eyerWandBuilder.uninit();
        }
    }
}
