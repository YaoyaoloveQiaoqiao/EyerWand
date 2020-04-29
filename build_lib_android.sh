cd Lib
rm -rf EyerLib
cd ../

cd EyerLib
cd Lib
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

cp -r EyerLib/Lib/install/ Lib/EyerLib