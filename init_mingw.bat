cd Eyer3rdpart/glfw-3.3.2
mkdir build
cd build
cmake -G"MinGW Makefiles" -DCMAKE_INSTALL_PREFIX=../glfw_install ../
mingw32-make clean
mingw32-make
mingw32-make install
cd ../
cd ../../

xcopy "Eyer3rdpart\glfw-3.3.2\glfw_install\*.*" "Lib\glfw_install\" /s/y



cd Eyer3rdpart/libyuv
mkdir build
cd build
cmake -G"MinGW Makefiles" -DCMAKE_INSTALL_PREFIX=../libyuv_install ../
mingw32-make clean
mingw32-make
mingw32-make install
cd ../
cd ../../

xcopy "Eyer3rdpart\libyuv\libyuv_install\*.*" "Lib\libyuv_install\" /s/y