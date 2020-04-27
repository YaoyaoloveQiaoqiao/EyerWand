basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

NDK=/Users/lichi/ndk_test/android-ndk-r21

cd Lib
rm -rf EyerWand
cd ../

cd EyerVideoWand
cd EyerVideoWand
mkdir build_a

rm -rf install

cd build_a

cmake ../ -DCMAKE_TOOLCHAIN_FILE=$NDK/build/cmake/android.toolchain.cmake -DANDROID_ABI=armeabi-v7a -DANDROID_NATIVE_API_LEVEL=21
make
make install

cd ..
rm -rf build_a

cd ..
cd ..

cp -r EyerVideoWand/EyerVideoWand/install/ Lib/EyerVideoWand

echo "================Update so to EyerWandEditor================"

cd ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs
rm -r armeabi-v7a
mkdir armeabi-v7a

cd ${basepath}

cp ${basepath}/Lib/EyerVideoWand/lib/libEyerWandJni.so ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs/armeabi-v7a/libEyerWandJni.so