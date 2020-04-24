if [ -d ./Eyer3rdpart ];then 
    rm -rf Eyer3rdpart
fi

basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

git clone https://gitee.com/redknot/Eyer3rdpart

ARCH=aarch64
HOST_TAG=darwin-x86_64
HOST=aarch64-linux-android
NDK=/Users/lichi/ndk_test/android-ndk-r21

export TOOLCHAIN=$NDK/toolchains/llvm/prebuilt/$HOST_TAG
export AR=$TOOLCHAIN/bin/aarch64-linux-android-ar
export AS=$TOOLCHAIN/bin/aarch64-linux-android-as
export NM=$TOOLCHAIN/bin/aarch64-linux-android-nm
export CC=$TOOLCHAIN/bin/aarch64-linux-android21-clang
export CXX=$TOOLCHAIN/bin/aarch64-linux-android21-clang++
export LD=$TOOLCHAIN/bin/aarch64-linux-android-ld
export RANLIB=$TOOLCHAIN/bin/aarch64-linux-android-ranlib
export STRIP=$TOOLCHAIN/bin/aarch64-linux-android-strip


cd ${basepath}/Eyer3rdpart/x264/

./configure \
--prefix=${basepath}/Eyer3rdpart/x264/x264_install \
--enable-static \
--disable-shared \
--enable-pic --enable-strip --disable-asm --disable-cli --disable-opencl \
--host=${HOST} \
--cross-prefix=$TOOLCHAIN/bin/aarch64-linux-android- 

make clean
make -j4
make install

cd ../../




cd ${basepath}/Eyer3rdpart/ffmpeg_3.2.14/
./configure \
--enable-static \
--disable-shared \
--prefix=./ffmpeg_install \
--enable-libx264 \
--enable-gpl \
--enable-pic \
--extra-cflags=-I${basepath}/Eyer3rdpart/x264/x264_install/include/ \
--extra-ldflags=-L${basepath}/Eyer3rdpart/x264/x264_install/lib/ \
--enable-cross-compile \
--target-os=android \
--arch=arm64 \
--cc=CC \
--cross-prefix=$TOOLCHAIN/bin/aarch64-linux-android-

make clean
make -j4
make install

cd ../../




cd ${basepath}/Eyer3rdpart/freetype-2.10.0
./configure \
--enable-static \
--enable-shared \
--host=${HOST} \
--prefix=${basepath}/Eyer3rdpart/freetype-2.10.0/freetype_install

make clean
make -j4
make install

cd ../../









cd ${basepath}/Eyer3rdpart/libpng-1.6.37
./configure \
--enable-static \
--enable-shared \
--enable-pic \
--host=${HOST} \
--prefix=${basepath}/Eyer3rdpart/libpng-1.6.37/libpng_install

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
# cp -r Eyer3rdpart/glfw-3.3.2/glfw_install Lib/glfw_install
cp -r Eyer3rdpart/freetype-2.10.0/freetype_install Lib/freetype_install
cp -r Eyer3rdpart/libpng-1.6.37/libpng_install Lib/libpng_install
cp -r Eyer3rdpart/libyuv/libyuv_install Lib/libyuv_install