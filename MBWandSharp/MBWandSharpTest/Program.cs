using System;
using MBWandSharp;

namespace MBWandSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MBWand.getVersion());

            MBWandBuilder eyerWandBuilder = new MBWandBuilder("./test.mp4", 1280, 720, 30);
            MBWandVideoTrack videoTrack = new MBWandVideoTrack();
            MBWandVideoLayer videoLayer = new MBWandVideoLayer(0, 30*5);
            MBWandVideoFragment videoFragment = new MBWandVideoFragment("./M_1280_720.mp4");

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
