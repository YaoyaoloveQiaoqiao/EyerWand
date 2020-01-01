cd Lib
rm -rf EyerLib
cd ../

cd EyerLib
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

cp -r EyerLib/Lib/install/ Lib/EyerLib