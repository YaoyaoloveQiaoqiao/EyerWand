basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

cd ${basepath}

if [ ! -d ./Lib ];then 
    mkdir Lib
fi

cd Lib
rm -rf EyerLib
cd ../

cd ${basepath}

cd EyerLib
cd Lib
mkdir build_a

rm -rf install

cd build_a

$CMAKE_HOME/bin/cmake -G"Unix Makefiles" ../
make
make install

cd ..
rm -rf build_a

cd ..
cd ..

cp -r EyerLib/Lib/install/ Lib/EyerLib