#include <jni.h>
#include <android/log.h>

#define LOG_TAG "NovaCore"
#define LOGI(...) __android_log_print(ANDROID_LOG_INFO, LOG_TAG, __VA_ARGS__)

extern "C" JNIEXPORT jint JNICALL
JNI_OnLoad(JavaVM* vm, void* /*reserved*/) {
    LOGI("NovaCore native library loaded");
    return JNI_VERSION_1_6;
}

extern "C" JNIEXPORT void JNICALL
Java_com_novacore_NovaCore_initialize(JNIEnv* /*env*/, jclass /*clazz*/) {
    LOGI("NovaCore initialized");
}
