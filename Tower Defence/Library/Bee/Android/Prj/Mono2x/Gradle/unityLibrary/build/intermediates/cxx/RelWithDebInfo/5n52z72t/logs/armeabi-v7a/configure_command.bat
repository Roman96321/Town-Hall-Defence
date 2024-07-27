@echo off
"D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\SDK\\cmake\\3.22.1\\bin\\cmake.exe" ^
  "-HD:\\GitHub\\TowerDefenseGame\\Tower Defence\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\src\\main\\cpp" ^
  "-DCMAKE_SYSTEM_NAME=Android" ^
  "-DCMAKE_EXPORT_COMPILE_COMMANDS=ON" ^
  "-DCMAKE_SYSTEM_VERSION=23" ^
  "-DANDROID_PLATFORM=android-23" ^
  "-DANDROID_ABI=armeabi-v7a" ^
  "-DCMAKE_ANDROID_ARCH_ABI=armeabi-v7a" ^
  "-DANDROID_NDK=D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK" ^
  "-DCMAKE_ANDROID_NDK=D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK" ^
  "-DCMAKE_TOOLCHAIN_FILE=D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK\\build\\cmake\\android.toolchain.cmake" ^
  "-DCMAKE_MAKE_PROGRAM=D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\SDK\\cmake\\3.22.1\\bin\\ninja.exe" ^
  "-DCMAKE_LIBRARY_OUTPUT_DIRECTORY=D:\\GitHub\\TowerDefenseGame\\Tower Defence\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\build\\intermediates\\cxx\\RelWithDebInfo\\5n52z72t\\obj\\armeabi-v7a" ^
  "-DCMAKE_RUNTIME_OUTPUT_DIRECTORY=D:\\GitHub\\TowerDefenseGame\\Tower Defence\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\build\\intermediates\\cxx\\RelWithDebInfo\\5n52z72t\\obj\\armeabi-v7a" ^
  "-DCMAKE_BUILD_TYPE=RelWithDebInfo" ^
  "-DCMAKE_FIND_ROOT_PATH=D:\\GitHub\\TowerDefenseGame\\Tower Defence\\.utmp\\RelWithDebInfo\\5n52z72t\\prefab\\armeabi-v7a\\prefab" ^
  "-BD:\\GitHub\\TowerDefenseGame\\Tower Defence\\.utmp\\RelWithDebInfo\\5n52z72t\\armeabi-v7a" ^
  -GNinja ^
  "-DANDROID_STL=c++_shared"
