basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

if [ -d ./Eyer3rdpart ];then 
    rm -rf Eyer3rdpart
fi

git clone https://gitee.com/redknot/Eyer3rdpart


files=$(ls $NDK/toolchains/llvm/prebuilt/)
HOST_TAG=$""
for filename in $files
do
    echo $filename
    HOST_TAG=$filename
done

# HOST_TAG=linux-x86_64
# HOST_TAG=darwin-x86_64
# HOST_TAG=windows-x86_64

echo "HOST_TAG:"$HOST_TAG

export TOOLCHAIN=$NDK/toolchains/llvm/prebuilt/$HOST_TAG


# Only choose one of these, depending on your device...
# export TARGET=aarch64-linux-android
export TARGET=armv7a-linux-androideabi
# export TARGET=i686-linux-android
# export TARGET=x86_64-linux-android


# Set this to your minSdkVersion.
export API=21

export CC=$TOOLCHAIN/bin/$TARGET$API-clang
export CXX=$TOOLCHAIN/bin/$TARGET$API-clang++

# export AR=$TOOLCHAIN/bin/$TARGET-ar
export AR=$TOOLCHAIN/bin/arm-linux-androideabi-ar
export AS=$TOOLCHAIN/bin/arm-linux-androideabi-as
export LD=$TOOLCHAIN/bin/arm-linux-androideabi-ld
export RANLIB=$TOOLCHAIN/bin/arm-linux-androideabi-ranlib
export STRIP=$TOOLCHAIN/bin/arm-linux-androideabi-strip


cd ${basepath}/Eyer3rdpart/x264/

./configure \
--prefix=${basepath}/Eyer3rdpart/x264/x264_install \
--enable-static \
--disable-shared \
--enable-pic --enable-strip --disable-asm --disable-cli --disable-opencl \
--host=${TARGET} \
# --cross-prefix=$TOOLCHAIN/bin/aarch64-linux-android- 

make clean
make -j4
make install

cd ../../




cd ${basepath}/Eyer3rdpart/ffmpeg_3.2.14/
./configure \
--enable-static \
--disable-shared \
--disable-ffmpeg \
--disable-ffplay \
--disable-ffprobe \
--disable-ffserver \
--disable-avdevice \
--disable-doc \
--disable-symver \
--prefix=./ffmpeg_install \
--enable-libx264 \
--enable-gpl \
--enable-pic \
--disable-neon \
--extra-cflags=-I${basepath}/Eyer3rdpart/x264/x264_install/include/ \
--extra-ldflags=-L${basepath}/Eyer3rdpart/x264/x264_install/lib/ \
--enable-cross-compile \
--target-os=android \
--arch=arm \
--nm=$TOOLCHAIN/bin/arm-linux-androideabi-nm \
--cc=$TOOLCHAIN/bin/$TARGET$API-clang \
--cross-prefix=$TOOLCHAIN/bin/arm-linux-androideabi-

make clean
make -j4
make install

cd ../../




cd ${basepath}/Eyer3rdpart/freetype-2.10.0
./configure \
--enable-static \
--disable-shared \
--without-zlib \
--with-png=no \
--with-harfbuzz=no \
--host=${TARGET} \
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
--host=${TARGET} \
--prefix=${basepath}/Eyer3rdpart/libpng-1.6.37/libpng_install

make clean
make -j4
make install





cd ${basepath}/Eyer3rdpart/libyuv
mkdir build
cd build
cmake ../ -DCMAKE_INSTALL_PREFIX=${basepath}/Eyer3rdpart/libyuv/libyuv_install -DCMAKE_TOOLCHAIN_FILE=$NDK/build/cmake/android.toolchain.cmake -DANDROID_ABI=armeabi-v7a -DANDROID_NATIVE_API_LEVEL=21
make
make install


cd ${basepath}


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