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
            float x = (right.x - left.x) / AllW;
            float y = (right.y - left.y) / AllH;
            Position positonWH = new Position(x, y);
            return positonWH;
        }

        //通过左上右下坐标，计算位置占比, type 1是图片，type2是文字
        Position getPosition(Position left, Position right, int AllH, int AllW, int type)
        {
            int halfH = AllH / 2;
            int halfW = AllW / 2;
            if (type == 1)
            {
                //图片中心的位置
                float x = left.x + (right.x - left.x) / 2;
                float y = left.y + (right.y - left.y) / 2;
                Position centerPosition = new Position(x, y);

                //转换成中心坐标系，单位1
                float x2 = (centerPosition.x - halfW) / 1280.0f;
                float y2 = (halfH - centerPosition.y) / 720.0f;
                Position centerCoordinatePosition = new Position(x2, y2);
                return centerCoordinatePosition;
            }else if(type == 2)
            {
                float x = left.x / AllW;
                float y = (left.y + 0.8f * (right.y - left.y))/ AllH;
                Position centerCoordinatePosition = new Position(x, y);
                return centerCoordinatePosition;
            }else if(type == 3)
            {
                //图片中心的位置
                float x = (left.x + (right.x - left.x) / 2)/ AllW;
                float y = (left.y + (right.y - left.y) / 2)/ AllH;
                Position centerPosition = new Position(x, y);
                return centerPosition;
            }
            return new Position(100, 100);
        }

        //词云 气泡
        void doc12()
        {
            //视频========================
            int fps = 20;
            //设置输出文件路径./test.mp4，视频宽1920，视频高1080，fps为30（固定参数）
            MBBuilder MBBuilder = new MBBuilder("./test_png.mp4", 1280, 720, fps);
            MBVideoTrack videoTrack = new MBVideoTrack();
            //设置一段视频开始时间和结束时间，开始时间0s，结束时间5s
            MBVideoLayer videoLayer = new MBVideoLayer(0, 2 * fps);
            MBVideoLayer textLayer = new MBVideoLayer(0, 2 * fps);

            //添加视频片段
            //设置添加素材路径
            MBVideoFragment videoFragment = new MBVideoFragment("./material/ciqipiao.mp4");
            //MBVideoFragment videoFragment = new MBVideoFragment("./material/Video_20200504102231---1.wmv");

            videoFragment.addScaleKey(0.0, 1280.0f, 720.0f, 0.0f);
            videoFragment.addScaleKey(2.0, 1280.0f, 720.0f, 0.0f);
            videoLayer.addFragment(videoFragment.fragment);
            videoTrack.addLayer(videoLayer.layer);

            //文字
            int AllH = 720;
            int AllW = 1280;

            PicStyle[] picSytles = new PicStyle[5];
            picSytles[0] = new PicStyle();
            Position leftPoint = new Position(478, 207);
            Position rightPoint = new Position(741, 470);

            picSytles[0].position = getPosition(leftPoint, rightPoint, AllH, AllW, 3);
            picSytles[0].withHeight = new Position(0, 41);
            picSytles[0].text = "recipes";
            //picSytles[0].transStart = new Position(-0.5f - picSytles[0].withHeight.x, picSytles[0].position.y);

            picSytles[1] = new PicStyle();
            leftPoint = new Position(847, 196);
            rightPoint = new Position(1054, 403);

            picSytles[1].position = getPosition(leftPoint, rightPoint, AllH, AllW, 3);
            picSytles[1].withHeight = new Position(0, 27);
            picSytles[1].transStart = new Position(0.5f + picSytles[1].withHeight.x, picSytles[1].position.y);
            picSytles[1].text = "instant";

            picSytles[2] = new PicStyle();
            leftPoint = new Position(259, 397);
            rightPoint = new Position(404, 542);

            picSytles[2].position = getPosition(leftPoint, rightPoint, AllH, AllW, 3);
            picSytles[2].withHeight = new Position(0, 27);
            picSytles[2].transStart = new Position(-0.5f - picSytles[2].withHeight.x, picSytles[2].position.y);
            picSytles[2].text = "pot";

            picSytles[3] = new PicStyle();
            leftPoint = new Position(669, 470);
            rightPoint = new Position(846, 646);

            picSytles[3].position = getPosition(leftPoint, rightPoint, AllH, AllW, 3);
            picSytles[3].withHeight = new Position(0, 24);
            picSytles[3].transStart = new Position(picSytles[3].position.x, -0.5f - picSytles[3].withHeight.y);
            picSytles[3].text = "rice";


            picSytles[4] = new PicStyle();
            leftPoint = new Position(841, 425);
            rightPoint = new Position(954, 538);

            picSytles[4].position = getPosition(leftPoint, rightPoint, AllH, AllW, 3);
            picSytles[4].withHeight = new Position(0, 21);
            picSytles[4].transStart = new Position(0.5f + picSytles[4].withHeight.x, picSytles[4].position.y);
            picSytles[4].text = "time";

            //for (int i = 0; i < picSytles.Length; i++)
            for (int i = 0; i < 1; i++)
            {
                //1.创建MBTextFragment
                MBTextFragment textFragment = new MBTextFragment("./SourceHanSansCN-Bold.otf", picSytles[i].text);
                
                //2.设置大小Size
                textFragment.setSize((int)(picSytles[i].withHeight.y));

                //3.获取文字长度
                int textWidth = textFragment.getTextWidth();

                //4.设置文字样式，size: 大小；x: x轴位置 圆心位置x - 文字宽度/2 ； y: y轴位置 圆心位置y + 文字高度/5 ; r: 颜色R值；g: 颜色G值；b: 颜色B值； 
                textFragment.set_text_style((int)(picSytles[i].withHeight.y), picSytles[i].position.x * AllW - (textWidth/2), picSytles[i].position.y * AllH +(picSytles[i].withHeight.y/5) , 1.0f, 1.0f, 1.0f, AllW);
               
                /*Console.WriteLine("size: " + (int)(picSytles[i].withHeight.y));
                Console.WriteLine("picSytles[i].position.x :" + (picSytles[i].position.x * AllW - (textWidth / 2)));
                Console.WriteLine("picSytles[i].position.y :" + (picSytles[i].position.y * AllH + (picSytles[i].withHeight.y / 2)));*/
                textLayer.addFragment(textFragment.textFragment);
                videoTrack.addLayer(textLayer.layer);

                textFragment.uninit();
            }
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            MBBuilder.process();

            MBBuilder.uninit();
            videoTrack.uninit();
            videoLayer.uninit();
            textLayer.uninit();
            videoFragment.uninit();
        }

        //新增图片飞入视频片段
        void doc13()
        {
            //视频========================
            int fps = 20;
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

            picSytles[0].position = getPosition(leftPoint, rightPoint, AllH, AllW,1);
            picSytles[0].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[0].transStart = new Position(-0.5f - picSytles[0].withHeight.x, picSytles[0].position.y);

            picSytles[1] = new PicStyle();
            leftPoint = new Position(728.0f, 42.0f);
            rightPoint = new Position(1057.0f, 226.0f);

            picSytles[1].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[1].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[1].transStart = new Position(0.5f + picSytles[1].withHeight.x, picSytles[1].position.y);

            picSytles[2] = new PicStyle();
            leftPoint = new Position(79.0f, 290.0f);
            rightPoint = new Position(403.0f, 470.0f);

            picSytles[2].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[2].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[2].transStart = new Position(-0.5f - picSytles[2].withHeight.x, picSytles[2].position.y);

            picSytles[3] = new PicStyle();
            leftPoint = new Position(496.0f, 268.0f);
            rightPoint = new Position(823.0f, 451.0f);

            picSytles[3].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[3].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[3].transStart = new Position(picSytles[3].position.x, -0.5f - picSytles[3].withHeight.y);

            picSytles[4] = new PicStyle();
            leftPoint = new Position(879.0f, 241.0f);
            rightPoint = new Position(1209.0f, 425.0f);

            picSytles[4].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[4].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[4].transStart = new Position(0.5f + picSytles[4].withHeight.x, picSytles[4].position.y);

            picSytles[5] = new PicStyle();
            leftPoint = new Position(333.0f, 486.0f);
            rightPoint = new Position(659.0f, 670.0f);

            picSytles[5].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[5].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[5].transStart = new Position(-0.5f - picSytles[5].withHeight.x, picSytles[5].position.y);

            picSytles[6] = new PicStyle();
            leftPoint = new Position(809.0f, 486.0f);
            rightPoint = new Position(1135.0f, 665.0f);

            picSytles[6].position = getPosition(leftPoint, rightPoint, AllH, AllW, 1);
            picSytles[6].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[6].transStart = new Position(0.5f + picSytles[6].withHeight.x, picSytles[6].position.y);

            for (int i = 0; i < picSytles.Length; i++)
            {
                MBVideoFragment videoFragment2 = new MBVideoFragment("./material/130" + i + ".jpg");

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

        void doc2()
        {
            //视频========================
            int fps = 20;
            //设置输出文件路径./test.mp4，视频宽1920，视频高1080，fps为30（固定参数）
            MBBuilder MBBuilder = new MBBuilder("./test_png.mp4", 1280, 720, fps);
            MBVideoTrack videoTrack = new MBVideoTrack();
            //设置一段视频开始时间和结束时间，开始时间0s，结束时间5s
            MBVideoLayer videoLayer = new MBVideoLayer(0, 3 * fps);
            MBVideoLayer textLayer = new MBVideoLayer(0, 3 * fps);

            //添加视频片段
            //设置添加素材路径
            MBVideoFragment videoFragment = new MBVideoFragment("./material/white.jpg");

            videoFragment.addScaleKey(0.0, 1280.0f, 720.0f, 0.0f);
            videoFragment.addScaleKey(3.0, 1280.0f, 720.0f, 0.0f);
            videoLayer.addFragment(videoFragment.fragment);
            videoTrack.addLayer(videoLayer.layer);

            //top
            MBVideoFragment videoFragmentTop = new MBVideoFragment("./material/top_summary1.jpg");

            videoFragmentTop.addScaleKey(0.0, 1280.0f, 100.0f, 0.0f);
            videoFragmentTop.addScaleKey(3.0, 1280.0f, 100.0f, 0.0f);
            videoFragmentTop.addTransKey(0.0, 0.0f, 720 / 2 - 50, 0.0f);
            videoLayer.addFragment(videoFragmentTop.fragment);
            videoTrack.addLayer(videoLayer.layer);

           /* MBVideoLayer textLayer1 = new MBVideoLayer(0, 6 * fps);
            MBVideoLayer textLayer2 = new MBVideoLayer(0, 6 * fps);

            //创建文字片段，参数，字体文件，文字内容
            MBTextFragment textFragement1 = new MBTextFragment("./SourceHanSansCN-Normal.otf", "The Best AAA BBBB");
            //设置文字样式，size: 大小；x: x轴位置； y: y轴位置; r: 颜色R值；g: 颜色G值；b: 颜色B值； 
            textFragement1.set_text_style(100, 0, 0, 1.0f, 1.0f, 0.0f, 1920);
            textLayer1.addTextFragment(textFragement1.textFragment);

            MBTextFragment textFragement2 = new MBTextFragment("./SourceHanSansCN-Normal.otf", "The Best AAA BBBB SJFLJFLJLFD");
            textFragement2.set_text_style(100, 0, 720, 1.0f, 0.0f, 0.0f, 1920);
            textLayer2.addTextFragment(textFragement2.textFragment);

            videoTrack.addLayer(textLayer1.layer);
            videoTrack.addLayer(textLayer2.layer);*/



            //文字
            int AllH = 720;
            int AllW = 1280;

            PicStyle[] picSytles = new PicStyle[7];
            picSytles[0] = new PicStyle();
            Position leftPoint = new Position(49, 25);
            Position rightPoint = new Position(329, 80);

            picSytles[0].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[0].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[0].text = "Summary";
            //picSytles[0].transStart = new Position(-0.5f - picSytles[0].withHeight.x, picSytles[0].position.y);

            picSytles[1] = new PicStyle();
            leftPoint = new Position(478, 13);
            rightPoint = new Position(804, 42);

            picSytles[1].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[1].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[1].transStart = new Position(0.5f + picSytles[1].withHeight.x, picSytles[1].position.y);
            picSytles[1].text = "Best Pressure Cooker";

            picSytles[2] = new PicStyle();
            leftPoint = new Position(60.0f, 173.0f);
            rightPoint = new Position(870.0f, 207.0f);

            picSytles[2].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[2].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[2].transStart = new Position(-0.5f - picSytles[2].withHeight.x, picSytles[2].position.y);
            picSytles[2].text = "Top 5 small appliances to cook healthy meal";

            picSytles[3] = new PicStyle();
            leftPoint = new Position(59.0f, 235.0f);
            rightPoint = new Position(536.0f, 256.0f);

            picSytles[3].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[3].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[3].transStart = new Position(picSytles[3].position.x, -0.5f - picSytles[3].withHeight.y);
            picSytles[3].text = "Reviews and ratings from 905,102 actual customers";


            picSytles[4] = new PicStyle();
            leftPoint = new Position(59.0f, 279.0f);
            rightPoint = new Position(257.0f, 299.0f);

            picSytles[4].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[4].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[4].transStart = new Position(0.5f + picSytles[4].withHeight.x, picSytles[4].position.y);
            picSytles[4].text = "customer reviews";

            picSytles[5] = new PicStyle();
            leftPoint = new Position(60.0f, 320.0f);
            rightPoint = new Position(241.0f, 366.0f);

            picSytles[5].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[5].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[5].transStart = new Position(-0.5f - picSytles[5].withHeight.x, picSytles[5].position.y);
            picSytles[5].text = "14,166";

            picSytles[6] = new PicStyle();
            leftPoint = new Position(809.0f, 486.0f);
            rightPoint = new Position(1135.0f, 665.0f);

            picSytles[6].position = getPosition(leftPoint, rightPoint, AllH, AllW, 2);
            picSytles[6].withHeight = getWH(leftPoint, rightPoint, AllH, AllW);
            picSytles[6].transStart = new Position(0.5f + picSytles[6].withHeight.x, picSytles[6].position.y);

            //for (int i = 0; i < picSytles.Length; i++)
            for (int i = 0; i < 6; i++)
            {
                MBTextFragment textFragment = new MBTextFragment("./SourceHanSansCN-Bold.otf", picSytles[i].text);
                //设置文字样式，size: 大小；x: x轴位置； y: y轴位置; r: 颜色R值；g: 颜色G值；b: 颜色B值； 

                textFragment.set_text_style((int)(picSytles[i].withHeight.y * AllH), picSytles[i].position.x * AllW, picSytles[i].position.y * AllH, 0.0f, 0.0f, 0.0f, AllW);
                Console.WriteLine("size: " + (int)(picSytles[i].withHeight.y * AllH));
                textLayer.addFragment(textFragment.textFragment);
                videoTrack.addLayer(textLayer.layer);

            }
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            MBBuilder.process();

            MBBuilder.uninit();
            videoTrack.uninit();
            videoLayer.uninit();
        }

        void hunyin2()
        {
            Console.WriteLine(MB.getVersion());
            //视频========================
            int pts = 20;
            //设置输出文件路径./test.mp4，视频宽1920，视频高1080，pts为30（固定参数）
            MBBuilder MBBuilder = new MBBuilder("./test_audio.mp4", 1280, 720, pts);
            MBVideoTrack videoTrack = new MBVideoTrack();
            //设置一段视频开始时间和结束时间，开始时间0s，结束时间5s
            MBVideoLayer videoLayer = new MBVideoLayer(0, 10 * pts);
            MBVideoLayer videoLayer2 = new MBVideoLayer(10 * pts, 14 * pts);

            //添加视频片段
            //设置添加素材路径
            MBVideoFragment videoFragment = new MBVideoFragment("./M_1280_720.mp4");

            //设置缩放效果，时间0.0s，缩放宽度1920.0， 缩放高度1080.0
            videoFragment.addScaleKey(0.0, 1280.0f, 720.0f, 0.0f);
            //设置缩放效果，时间5.0s，缩放宽度1920.0/2， 缩放高度1080.0/2
            videoFragment.addScaleKey(5.0, 1280.0f, 720.0f, 0.0f);

            //设置抖动效果
            /*videoFragment.addTransKey(0.0, 0.0f, 0.0f, 0.0f);
            //时间0.1s, x轴位移-30像素，y轴位移-30像素，z轴位移0像素
            videoFragment.addTransKey(2.1, -30.0f, -30.0f, 0.0f);
            videoFragment.addTransKey(2.2, 30.0f, 30.0f, 0.0f);
            videoFragment.addTransKey(2.3, -20.0f, -20.0f, 0.0f);
            videoFragment.addTransKey(2.4, 20.0f, 20.0f, 0.0f);
            videoFragment.addTransKey(2.5, 10.0f, 10.0f, 0.0f);
            videoFragment.addTransKey(2.6, 0.0f, 0.0f, 0.0f);*/

            //注：目前一个videoFragment只能有一种Filter，即只能选ZOOM_BLUR或GAUSSIAN_BLUR，代码片段@1和@2不能同时存在。

            //径向模糊效果 @1=======================
            //设置径向模糊，时间0.0s, filter类型ZOOM_BLUR，模糊程度10
            /*videoFragment.addFilter(0.0, (int)filterType.ZOOM_BLUR, 10);
            videoFragment.addFilter(1.2, (int)filterType.ZOOM_BLUR, 0);*/
            //径向模糊效果end=======================

            //高斯模糊效果 @2=======================
            //设置高斯模糊，时间0.0s, filter类型GAUSSIAN_BLUR，模糊程度1
            //videoFragment.addFilter(0.0, (int)filterType.GAUSSIAN_BLUR, 8);
            //videoFragment.addFilter(2.0, (int)filterType.GAUSSIAN_BLUR, 0);
            //高斯模糊效果end=======================

            //添加图片
            //设置添加素材路径
           


            //音频========================
            //创建音频轨
            MBAudioTrack audioTrack = new MBAudioTrack();
            //创建音频layer（概念与视频类似），并设置音频开始结束时间 单位：秒
            MBAudioLayer auidoLayer1 = new MBAudioLayer(0.0, 20.0);
            MBAudioLayer auidoLayer2 = new MBAudioLayer(0.0, 20.0);

            //创建一段音频
            //MBAudioFragment audioFragment1 = new MBAudioFragment("./1.aac");
            //MBAudioFragment audioFragment1 = new MBAudioFragment("./page4.aac");
            MBAudioFragment audioFragment1 = new MBAudioFragment("./page4_2.aac");

            //设置音量权重，混音总权重是1，各个分量之和必须为1,该例子中，背景音乐权重设置0.2，旁边权重设置0.8
            //audioFragment1.setWeight(0.2f);
            //创建另一段音频
            MBAudioFragment audioFragment2 = new MBAudioFragment("./bgm.aac");
            //audioFragment2.setWeight(0.8f);
            
            //开始对音频组合
            auidoLayer1.addFragment(audioFragment1.audioFragment);
            auidoLayer2.addFragment(audioFragment2.audioFragment);

            audioTrack.addLayer(auidoLayer1.audioLayer);
            audioTrack.addLayer(auidoLayer2.audioLayer);
            //audioTrack.addLayer(auidoLayer3.audioLayer);

           
            //居中逐个字显示字幕end==========================

            //builder中添加视频轨
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            //builder中添加音频轨
            MBBuilder.addAudioTrack(audioTrack.audioTrackP);

            MBBuilder.process();

            //#### new 出来的资源一定要调用uninit方法，释放所有资源，否则会造成内存泄漏
            videoFragment.uninit();
            videoLayer.uninit();
            videoTrack.uninit();

            audioFragment2.uninit();
            auidoLayer1.uninit();
            audioTrack.uninit();

            MBBuilder.uninit();
        }
        //混音
        void hunyin()
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



            //音频========================
            //创建音频轨
            MBAudioTrack audioTrack = new MBAudioTrack();
            //创建音频layer（概念与视频类似），并设置音频开始结束时间 单位：秒
            MBAudioLayer auidoLayer1 = new MBAudioLayer(0.0, 5.0);
            MBAudioLayer auidoLayer2 = new MBAudioLayer(0.0, 5.0);
            //创建一段音频
            MBAudioFragment audioFragment1 = new MBAudioFragment("./1.aac");
            //设置音量权重，混音总权重是1，各个分量之和必须为1,该例子中，背景音乐权重设置0.2，旁边权重设置0.8
            //audioFragment1.setWeight(0.2f);
            //创建另一段音频
            MBAudioFragment audioFragment2 = new MBAudioFragment("./bgm.aac");
            //audioFragment2.setWeight(0.8f);

            //开始对音频组合
            auidoLayer1.addFragment(audioFragment1.audioFragment);
            auidoLayer2.addFragment(audioFragment2.audioFragment);

            audioTrack.addLayer(auidoLayer1.audioLayer);
            audioTrack.addLayer(auidoLayer2.audioLayer);

            MBBuilder.addVideoTrack(audioTrack.audioTrackP);
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            MBBuilder.process();

            MBBuilder.uninit();
            audioTrack.uninit();
            auidoLayer1.uninit();
            auidoLayer2.uninit();
        }

        //色差测试
        void colorTest()
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

            MBVideoFragment videoFragment1 = new MBVideoFragment("./material/eggCooker.jpg");

            videoFragment1.addScaleKey(0.0, 200, 200, 0.0f);
            videoFragment1.addScaleKey(5.0, 200, 200, 0.0f);
            videoFragment1.addTransKey(0.0, -400, 0, 0);
            videoFragment1.addTransKey(5.0, -400, 0, 0);
            videoLayer.addFragment(videoFragment1.fragment);
            videoTrack.addLayer(videoLayer.layer);

            MBVideoFragment videoFragment2 = new MBVideoFragment("./material/qipao.mp4");

            videoFragment2.addScaleKey(0.0, 400.0f, 400.0f, 0.0f);
            videoFragment2.addScaleKey(5.0, 400.0f, 400.0f, 0.0f);
            videoLayer.addFragment(videoFragment2.fragment);
            videoTrack.addLayer(videoLayer.layer);

            MBVideoFragment videoFragment3 = new MBVideoFragment("./material/start.mp4");

            videoFragment3.addScaleKey(0.0, 500, 500, 0.0f);
            videoFragment3.addScaleKey(5.0, 500, 500, 0.0f);
            videoFragment3.addTransKey(0.0, 500, 0, 0);
            videoFragment3.addTransKey(5.0, 500, 0, 0);
            videoLayer.addFragment(videoFragment3.fragment);
            videoTrack.addLayer(videoLayer.layer);

            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            MBBuilder.process();

            MBBuilder.uninit();
      
        }

        void hunyin3()
        {
            Console.WriteLine(MB.getVersion());
            //视频========================
            int pts = 20;
            //设置输出文件路径./test.mp4，视频宽1920，视频高1080，pts为30（固定参数）
            MBBuilder MBBuilder = new MBBuilder("./test_audio.mp4", 1280, 720, pts);
            MBVideoTrack videoTrack = new MBVideoTrack();
            //设置一段视频开始时间和结束时间，开始时间0s，结束时间5s
            MBVideoLayer videoLayer = new MBVideoLayer(0, 10 * pts);
            MBVideoLayer videoLayer2 = new MBVideoLayer(10 * pts, 14 * pts);

            //添加视频片段
            //设置添加素材路径
            MBVideoFragment videoFragment = new MBVideoFragment("./M_1280_720.mp4");

            //设置缩放效果，时间0.0s，缩放宽度1920.0， 缩放高度1080.0
            videoFragment.addScaleKey(0.0, 1280.0f, 720.0f, 0.0f);
            //设置缩放效果，时间5.0s，缩放宽度1920.0/2， 缩放高度1080.0/2
            videoFragment.addScaleKey(5.0, 1280.0f, 720.0f, 0.0f);

            //设置抖动效果
            /*videoFragment.addTransKey(0.0, 0.0f, 0.0f, 0.0f);
            //时间0.1s, x轴位移-30像素，y轴位移-30像素，z轴位移0像素
            videoFragment.addTransKey(2.1, -30.0f, -30.0f, 0.0f);
            videoFragment.addTransKey(2.2, 30.0f, 30.0f, 0.0f);
            videoFragment.addTransKey(2.3, -20.0f, -20.0f, 0.0f);
            videoFragment.addTransKey(2.4, 20.0f, 20.0f, 0.0f);
            videoFragment.addTransKey(2.5, 10.0f, 10.0f, 0.0f);
            videoFragment.addTransKey(2.6, 0.0f, 0.0f, 0.0f);*/

            //注：目前一个videoFragment只能有一种Filter，即只能选ZOOM_BLUR或GAUSSIAN_BLUR，代码片段@1和@2不能同时存在。

            //径向模糊效果 @1=======================
            //设置径向模糊，时间0.0s, filter类型ZOOM_BLUR，模糊程度10
            /*videoFragment.addFilter(0.0, (int)filterType.ZOOM_BLUR, 10);
            videoFragment.addFilter(1.2, (int)filterType.ZOOM_BLUR, 0);*/
            //径向模糊效果end=======================

            //高斯模糊效果 @2=======================
            //设置高斯模糊，时间0.0s, filter类型GAUSSIAN_BLUR，模糊程度1
            //videoFragment.addFilter(0.0, (int)filterType.GAUSSIAN_BLUR, 8);
            //videoFragment.addFilter(2.0, (int)filterType.GAUSSIAN_BLUR, 0);
            //高斯模糊效果end=======================

            //添加图片
            //设置添加素材路径



            //音频========================
            //创建音频轨
            MBAudioTrack audioTrack = new MBAudioTrack();
            //创建音频layer（概念与视频类似），并设置音频开始结束时间 单位：秒
            MBAudioLayer auidoLayer1 = new MBAudioLayer(0.0, 10.0);
            MBAudioLayer auidoLayer2 = new MBAudioLayer(0.0, 10.0);

            //创建一段音频
            MBAudioFragment audioFragment1 = new MBAudioFragment("./1.aac");
            //设置音量权重，混音总权重是1，各个分量之和必须为1,该例子中，背景音乐权重设置0.2，旁边权重设置0.8
            //audioFragment1.setWeight(0.2f);
            //创建另一段音频
            MBAudioFragment audioFragment2 = new MBAudioFragment("./bgm.aac");
            //audioFragment2.setWeight(0.8f);

            //开始对音频组合
            auidoLayer1.addFragment(audioFragment1.audioFragment);
            auidoLayer2.addFragment(audioFragment2.audioFragment);

            audioTrack.addLayer(auidoLayer1.audioLayer);
            audioTrack.addLayer(auidoLayer2.audioLayer);
            //audioTrack.addLayer(auidoLayer3.audioLayer);


            //居中逐个字显示字幕end==========================

            //builder中添加视频轨
            MBBuilder.addVideoTrack(videoTrack.videoTrackP);
            //builder中添加音频轨
            MBBuilder.addAudioTrack(audioTrack.audioTrackP);

            MBBuilder.process();

            //#### new 出来的资源一定要调用uninit方法，释放所有资源，否则会造成内存泄漏
            videoFragment.uninit();
            videoLayer.uninit();
            videoTrack.uninit();

            audioFragment2.uninit();
            auidoLayer1.uninit();
            audioTrack.uninit();

            MBBuilder.uninit();
        }
        static void Main(string[] args)
        {
            MBTest test = new MBTest();

            //test.doc2();
            //test.hunyin2();
            //test.colorTest();
            //test.hunyin3();
            test.doc12();
        }
           
    }
}
