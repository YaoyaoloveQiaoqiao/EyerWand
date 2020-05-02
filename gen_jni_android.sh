basepath=$(cd `dirname $0`; pwd)
echo ${basepath}

cd ${basepath}

cd ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/java/

javac -h ./ com/eyer/eyer_wand_editor_lib/EyerWandNative.java

cd com/eyer/eyer_wand_editor_lib/

rm EyerWandNative.class

cd ${basepath}/EyerWandEditor/EyerWandEditorAndroid/eyer_wand_editor_lib/src/main/java/

mv com_eyer_eyer_wand_editor_lib_EyerWandNative.h ${basepath}/EyerVideoWand/EyerVideoWand/EyerWandJni/