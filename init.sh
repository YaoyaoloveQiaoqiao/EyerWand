if [ -d ./Eyer3rdpart ];then 
    rm -rf Eyer3rdpart
fi

git clone https://github.com/redknotmiaoyuqiao/Eyer3rdpart

cd Eyer3rdpart/x264/

./configure --prefix=./x264_install --enable-static --enable-shared
make clean
make -j4
make install


cd ../../


cd Eyer3rdpart/ffmpeg_3.2.14/
./configure --enable-static --enable-shared --prefix=./ffmpeg_install --enable-libx264 --enable-gpl --extra-cflags=-I../x264/x264_install/include/ --extra-ldflags=-L../x264/x264_install/lib/ 

make clean
make -j4
make install

cd ../../


cd Eyer3rdpart/glfw-3.3.2
mkdir build
cd build
cmake -DCMAKE_INSTALL_PREFIX=../glfw_install ../
make
make install

cd ../

cd ../../

if [ -d ./Lib ];then
    rm -rf Lib
fi

mkdir Lib

cp -r Eyer3rdpart/x264/x264_install Lib/x264_install
cp -r Eyer3rdpart/ffmpeg_3.2.14/ffmpeg_install Lib/ffmpeg_install
cp -r Eyer3rdpart/glfw-3.3.2/glfw_install Lib/glfw_install









git clone https://github.com/redknotmiaoyuqiao/EyerLib

git clone https://github.com/redknotmiaoyuqiao/EyerVideoWand
