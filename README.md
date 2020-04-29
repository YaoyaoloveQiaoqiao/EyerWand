# Eyer Wand

### ！！！ 使用本软件之前，请先阅读根目录下 LICENSE.md 的许可证内容，在您认可并承诺遵守许可证的内容之后，方可使用。！！！

# 安装和使用 How-to-install

ing...

# 构建 Build

我们是在 Unix-like 的环境里开发的 EyerWand。

建议你使用我们已经编译好的版本，点击[这里](https://github.com/redknotmiaoyuqiao/EyerWand "prebuild")下载。

但是如果你想自己编译 EyerWand 也可以，你需要事先安装 git， cmake， 和 make 。

----

We developed EyerWand under Unix-like environment. 

We recommend you use our prebuild release in [here](https://github.com/redknotmiaoyuqiao/EyerWand "prebuild").


But if you need build EyerWand by yourself, you hava to install git, cmake, and make first.

## Linux

````
sh init.sh
sh build_lib.sh
````

## Mac

````
sh init.sh
sh build_lib.sh
````

## Windows

在 windows 下，你需要先安装 Msys2， 使用 Msys2 进行编译。

In windows, you hava to install Msys2 first.

如果你是新安装的 Msys2，那么你要先安装这些软件。

If you are newer Msys2 user, you hava to install these pkg.

````
pacman -Su
pacman -S git
pacman -S mingw-w64-x86_64-toolchain
pacman -S yasm
pacman -S nasm
pacman -S base-devel
````

此外，我们还需要 cmake，我们经过测试发现 Msys2 包管理中的 cmake 存在一些问题，因此，我们建议你在 Windows 下安装 cmake，然后在 Msys2 中引用。
````
export CMAKE_HOME=/c/cmake
````

````
git clone https://github.com/redknotmiaoyuqiao/EyerWand
sh init_msys.sh
sh build_lib_msys.sh
````

## Android 

目前我们使用 Ubuntu 作为宿主环境，其他平台可能有问题。

开始之前，请先设置 NDK 的位置

````
export NDK=/Users/lichi/ndk_test/android-ndk-r21
````

首先运行 init_android.sh , 来下载第三方库，和对第三方库进行交叉编译。
````
sh init_android.sh
````

然后再运行 build_lib_android.sh 对 EyerLib 进行编译
````
sh build_lib_android.sh
````

然后再运行 build_wand_android.sh 对 EyerVideoWand 进行编译
````
sh build_wand_android.sh
````

之后用 Android Studio 打开 EyerWandEditor 里的 Android 工程，进行编译和打包就行了



# 百科 Wiki

ing...
