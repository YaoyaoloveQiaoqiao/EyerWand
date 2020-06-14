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
            EyerWandVideoLayer videoLayer = new EyerWandVideoLayer(0, 30*5);
            EyerWandVideoFragment videoFragment = new EyerWandVideoFragment("./M_1280_720.mp4");

            videoLayer.addFragment(videoFragment.fragment);
            videoTrack.addLayer(videoLayer.layer);
            eyerWandBuilder.addVideoTrack(videoTrack.videoTrackP);

            eyerWandBuilder.process();

            videoFragment.uninit();
            videoLayer.uninit();
            videoTrack.uninit();
            eyerWandBuilder.uninit();
        }
    }
}
