cd Lib
rm -rf MBLib
cd ../

cd MBLib
cd Lib
mkdir build_a

rm -rf install

cd build_a

cmake ../
make
make install

cd ..
rm -rf build_a

cd ..
cd ..

cp -r MBLib/Lib/install/ Lib/MBLib