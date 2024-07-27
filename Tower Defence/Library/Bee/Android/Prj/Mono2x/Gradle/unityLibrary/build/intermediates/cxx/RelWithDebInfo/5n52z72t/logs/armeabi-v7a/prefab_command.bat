@echo off
"D:\\Unity 3d\\6000.0.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\OpenJDK\\bin\\java" ^
  --class-path ^
  "C:\\Users\\Lenovo\\.gradle\\caches\\modules-2\\files-2.1\\com.google.prefab\\cli\\2.0.0\\f2702b5ca13df54e3ca92f29d6b403fb6285d8df\\cli-2.0.0-all.jar" ^
  com.google.prefab.cli.AppKt ^
  --build-system ^
  cmake ^
  --platform ^
  android ^
  --abi ^
  armeabi-v7a ^
  --os-version ^
  23 ^
  --stl ^
  c++_shared ^
  --ndk-version ^
  23 ^
  --output ^
  "C:\\Users\\Lenovo\\AppData\\Local\\Temp\\agp-prefab-staging9570398821697425138\\staged-cli-output" ^
  "C:\\Users\\Lenovo\\.gradle\\caches\\transforms-3\\268849a49ea9eb2bba6f4e0ac95bfd63\\transformed\\jetified-games-frame-pacing-1.10.0\\prefab"
