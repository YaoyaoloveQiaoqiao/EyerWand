if [ -d ./Eyer3rdpart ];then 
    rm -rf Eyer3rdpart
fi

basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

git clone https://github.com/redknotmiaoyuqiao/Eyer3rdpart

cd ${basepath}/Eyer3rdpart/x264/

./configure --prefix=${basepath}/Eyer3rdpart/x264/x264_install --enable-static --disable-shared --enable-pic
make clean
make -j4
make install

cd ../../

cd ${basepath}/Eyer3rdpart/ffmpeg_3.2.14/
./configure --enable-static --enable-shared --prefix=./ffmpeg_install --enable-libx264 --enable-gpl --enable-pic --extra-cflags=-I${basepath}/Eyer3rdpart/x264/x264_install/include/ --extra-ldflags=-L${basepath}/Eyer3rdpart/x264/x264_install/lib/

make clean
make -j4
make install

cd ../../

cd ${basepath}/Eyer3rdpart/freetype-2.10.0
./configure --enable-static --enable-shared --prefix=${basepath}/Eyer3rdpart/freetype-2.10.0/freetype_install
make clean
make -j4
make install

cd ../../

cd ${basepath}/Eyer3rdpart/libpng-1.6.37
./configure --enable-static --enable-shared --enable-pic --prefix=${basepath}/Eyer3rdpart/libpng-1.6.37/libpng_install
make clean
make -j4
make install

cd ${basepath}/Eyer3rdpart/glfw-3.3.2
mkdir build
cd build
$CMAKE_HOME/bin/cmake -G"Unix Makefiles" -DCMAKE_INSTALL_PREFIX=../glfw_install ../
make clean
make -j4
make install

cd ${basepath}/Eyer3rdpart/libyuv
mkdir build
cd build
$CMAKE_HOME/bin/cmake -G"Unix Makefiles" -DCMAKE_INSTALL_PREFIX=../libyuv_install ../
make clean
make -j4
make install


cd ${basepath}

if [ -d ./Lib ];then
    rm -rf Lib
fi

mkdir Lib

cp -r Eyer3rdpart/x264/x264_install Lib/x264_install
cp -r Eyer3rdpart/ffmpeg_3.2.14/ffmpeg_install Lib/ffmpeg_install
cp -r Eyer3rdpart/freetype-2.10.0/freetype_install Lib/freetype_install
cp -r Eyer3rdpart/libpng-1.6.37/libpng_install Lib/libpng_install

cp -r Eyer3rdpart/glfw-3.3.2/glfw_install Lib/glfw_install
cp -r Eyer3rdpart/libyuv/libyuv_install Lib/libyuv_install



git clone https://github.com/redknotmiaoyuqiao/EyerLib

git clone https://github.com/redknotmiaoyuqiao/EyerVideoWand