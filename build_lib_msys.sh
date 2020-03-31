cd Lib
rm -rf MBLib
cd ../

cd MBLib
cd MBLib
mkdir build_a

rm -rf install

cd build_a

$CMAKE_HOME/bin/cmake -G"Unix Makefiles" ../
make -j4
make install

cd ..
rm -rf build_a

cd ..
cd ..

cp -r MBLib/MBLib/install/ Lib/MBLib