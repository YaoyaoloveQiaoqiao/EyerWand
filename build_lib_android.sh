basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

cd ${basepath}

if [ ! -d ./Lib ];then 
    mkdir Lib
fi

cd Lib
rm -r EyerLib
cd ../

cd ${basepath}/EyerLib/Lib

mkdir build_a

if [ -d ./install ];then 
    rm -rf install
fi

cd build_a

# NDK=/Users/lichi/ndk_test/android-ndk-r21
# NDK=/home/redknot/NDK/android-ndk-r21

cmake ../ -DCMAKE_TOOLCHAIN_FILE=$NDK/build/cmake/android.toolchain.cmake -DANDROID_ABI=armeabi-v7a -DANDROID_NATIVE_API_LEVEL=21
make -j4
make install

cd ${basepath}/EyerLib/Lib

if [ -d ./build_a ];then 
    rm -rf build_a
fi

cd ${basepath}

cp -r EyerLib/Lib/install/ Lib/EyerLib


cd ${basepath}/Lib/EyerLib/lib

HOST_TAG=linux-x86_64
# HOST_TAG=darwin-x86_64

export TOOLCHAIN=$NDK/toolchains/llvm/prebuilt/$HOST_TAG

export TARGET=armv7a-linux-androideabi
export API=21

export CC=$TOOLCHAIN/bin/$TARGET$API-clang
export CXX=$TOOLCHAIN/bin/$TARGET$API-clang++

export AR=$TOOLCHAIN/bin/arm-linux-androideabi-ar
export AS=$TOOLCHAIN/bin/arm-linux-androideabi-as
export LD=$TOOLCHAIN/bin/arm-linux-androideabi-ld
export RANLIB=$TOOLCHAIN/bin/arm-linux-androideabi-ranlib
export STRIP=$TOOLCHAIN/bin/arm-linux-androideabi-strip

$AR x libEyerAV.a
$AR x libEyerCore.a
$AR x libEyerCrop.a
$AR x libEyerGL.a
$AR x libEyerGLContext.a
$AR x libEyerGLShader.a
$AR x libEyerGPUDomino.a
$AR x libEyerImg.a
$AR x libEyerThread.a
$AR x libEyerType.a
$AR x libEyerYUV.a
$AR x libEyerVideoTweenAnimation.a

$AR rcs libEyerLib.a *.o
#$CC -o libEyerLib.a *.o
