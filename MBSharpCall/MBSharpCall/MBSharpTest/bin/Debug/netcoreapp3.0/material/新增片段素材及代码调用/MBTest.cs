using System;
using MBSharp;
using System.Text;

namespace MBSharpTest
{
    class MBTest
    {     
        //通过左上右下坐标，计算长宽占比
        Position getWH(Position left, Position right, int AllH, int AllW)
        {
            float x = (right.x - left.x) / 1280.0f;
            float y = (right.y - left.y) / 720.0f;
            Position positonWH = new Position(x, y);
            return positonWH;
        }

        //通过左上右下坐标，计算位置占比
        Position getPosition(Position left, Position right, int AllH, int AllW)
        {
            int halfH = AllH / 2;
            int halfW = AllW / 2;
            //图片中心的位置
            float x = left.x + (right.x - left.x) / 2;
            float y = left.y + (right.y - left.y) / 2;
            Position centerPosition = new Position(x, y);

            //转换成中心坐标系，单位1
            float x2 = (centerPosition.x - halfW) / 1280.0f;
            float y2 = (halfH - centerPosition.y) / 720.0f;
            Position centerCoordinatePosition = new Position(x2, y2);
            return centerCoordinatePosition;
        }

        //新增图片飞入视频片段
        void doc13()
        {
            //视频========================
            int fps = 30;
            //设置输出文件路径./test.mp4，视频宽1920，视频高1080，fps为30（固定参数）
            MBBuilder MBBuilder = new MBBuilder("./test_png.mp4", 1280, 720, fps);
            MBVideoTrack videoTrack = new MBVideoTrack();
            //设置一段视频开始时间和结束时间，开始时间0s，结束时间5s
            MBVideoLayer videoLayer = new MBVideoLayer(0, 5 * fps);

            //添加视频片段
            //设置添加素材路径
            MBVideoFragment videoFragment = new MBVideoFragment("./material/white.jpg");

            videoFragment.addScaleKey(0.0, 1280.0f, 720.0f, 0.0f);
            videoFragment.addScaleKey(5.0, 1280.0f, 720.0f, 0.0f);
            videoLayer.addFragment(videoFragment.fragment);
            videoTrack.addLayer(videoLayer.layer);

            //图片
            int AllH = 720;
            int AllW = 1280;

            PicStyle[] picSytles = new PicStyle[7];
            picSytles[0] = new PicStyle();
            Position leftPoint = new Position(150.0f, 72.0f);
            Position rightPoint = new Position(479.0f, 257.0f);

            picSytles[0].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[0].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[0].transStart = new Position(-0.5f - picSytles[0].withHeight.x, picSytles[0].position.y);

            picSytles[1] = new PicStyle();
            leftPoint = new Position(728.0f, 42.0f);
            rightPoint = new Position(1057.0f, 226.0f);

            picSytles[1].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[1].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[1].transStart = new Position(0.5f + picSytles[1].withHeight.x, picSytles[1].position.y);

            picSytles[2] = new PicStyle();
            leftPoint = new Position(79.0f, 290.0f);
            rightPoint = new Position(403.0f, 470.0f);

            picSytles[2].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[2].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[2].transStart = new Position(-0.5f - picSytles[2].withHeight.x, picSytles[2].position.y);

            picSytles[3] = new PicStyle();
            leftPoint = new Position(496.0f, 268.0f);
            rightPoint = new Position(823.0f, 451.0f);

            picSytles[3].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[3].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[3].transStart = new Position(picSytles[3].position.x, -0.5f - picSytles[3].withHeight.y);

            picSytles[4] = new PicStyle();
            leftPoint = new Position(879.0f, 241.0f);
            rightPoint = new Position(1209.0f, 425.0f);

            picSytles[4].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[4].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[4].transStart = new Position(0.5f + picSytles[4].withHeight.x, picSytles[4].position.y);

            picSytles[5] = new PicStyle();
            leftPoint = new Position(333.0f, 486.0f);
            rightPoint = new Position(659.0f, 670.0f);

            picSytles[5].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[5].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[5].transStart = new Position(-0.5f - picSytles[5].withHeight.x, picSytles[5].position.y);

            picSytles[6] = new PicStyle();
            leftPoint = new Position(809.0f, 486.0f);
            rightPoint = new Position(1135.0f, 665.0f);

            picSytles[6].position = getPosition(leftPoint, rightPoint, AllH, AllW);
            picSytles[6].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[6].transStart = new Position(0.5f + picSytles[6].withHeight.x, picSytles[6].position.y);

            for (int i = 0; i < picSytles.Length; i++)
            {
                MBVideoFragment videoFragment2 = new MBVideoFragment("./material/130"+ i +".jpg");

                videoFragment2.addScaleKey(0.0, picSytles[i].withHeight.x * AllW, picSytles[i].withHeight.y * AllH, 0.0f);
                videoFragment2.addScaleKey(5.0, picSytles[i].withHeight.x * AllW, picSytles[i].withHeight.y * AllH, 0.0f);

                videoFragment2.addTransKey(0.0, picSytles[i].transStart.x * AllW, picSytles[i].transStart.y * AllH, 0.0f);
                videoFragment2.addTransKey(1.0, picSytles[i].position.x * AllW, picSytles[i].position.y * AllH, 0.0f);
                videoFragment2.addTransKey(5.0, picSytles[i].position.x * AllW, picSytles[i].position.y * AllH, 0.0f);

                videoLayer.addFragment(videoFragment2.fragment);
            }
            videoTrack.addLayer(videoLayer.layer);
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            MBBuilder.process();

            MBBuilder.uninit();
            videoTrack.uninit();
            videoLayer.uninit();
        }

        static void Main(string[] args)
        {
            MBTest test = new MBTest();

            test.doc13();
        }
           
    }
}
