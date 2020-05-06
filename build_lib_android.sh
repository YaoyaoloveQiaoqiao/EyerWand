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

cmake ../ -DCMAKE_TOOLCHAIN_FILE=$NDK/build/cmake/android.toolchain.cmake -DANDROID_ABI=armeabi-v7a -DANDROID_NATIVE_API_LEVEL=21 -DBUILD_TYPE=Release
make -j4
make install

cd ${basepath}/EyerLib/Lib

if [ -d ./build_a ];then 
    rm -rf build_a
fi

cd ${basepath}

cp -r EyerLib/Lib/install/ Lib/EyerLib