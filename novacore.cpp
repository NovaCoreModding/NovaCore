#include <jni.h>
#include <android/log.h>

#define LOG_TAG "NovaCore"
#define LOGI(...) __android_log_print(ANDROID_LOG_INFO, LOG_TAG, __VA_ARGS__)

extern "C"
JNIEXPORT void JNICALL
Java_com_novacore_nativeapp_MainActivity_00024NovaCore_initialize(JNIEnv* env, jclass clazz) {
    LOGI("NovaCore native library initialized");
}
