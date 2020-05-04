basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

# NDK=/Users/lichi/ndk_test/android-ndk-r21
# NDK=/home/redknot/NDK/android-ndk-r21

cd Lib
rm -rf EyerWand
cd ../

cd EyerVideoWand
cd EyerVideoWand
mkdir build_a

rm -rf install

cd build_a

cmake ../ -DCMAKE_TOOLCHAIN_FILE=$NDK/build/cmake/android.toolchain.cmake -DANDROID_ABI=armeabi-v7a -DANDROID_NATIVE_API_LEVEL=21 -DBUILD_TYPE=Release
make
make install

cd ..
rm -rf build_a

cd ..
cd ..

echo ""
echo ""
echo ""
echo ""
echo ""
echo "================Gen so libEyerWandJni.so================"
cd ${basepath}/EyerVideoWand/EyerVideoWand/install/lib
ls -lh


cd ${basepath}/Lib/
if [ -d ./EyerVideoWand ];then 
    rm -rf EyerVideoWand
fi

cp -r ${basepath}/EyerVideoWand/EyerVideoWand/install/ ${basepath}/Lib/EyerVideoWand

cd ${basepath}/Lib/EyerVideoWand/lib
ls -lh

echo "================Gen so libEyerWandJni.so================"
echo ""
echo ""
echo ""
echo ""
echo ""


echo "================Update so to EyerWandEditor================"

cd ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs

if [ -d ./armeabi-v7a ];then 
    rm -rf armeabi-v7a
fi
mkdir armeabi-v7a
cd armeabi-v7a



cd ${basepath}

cp ${basepath}/Lib/EyerVideoWand/lib/libEyerWandJni.so ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs/armeabi-v7a/libEyerWandJni.so
# cp ${basepath}/Lib/EyerVideoWand/lib/libEyerWand.so ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs/armeabi-v7a/libEyerWand.so

cd ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/jniLibs/armeabi-v7a
ls -lh