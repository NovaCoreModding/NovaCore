package com.novacore.nativeapp;

import android.app.Activity;
import android.os.Bundle;

public class MainActivity extends Activity {
    static {
        System.loadLibrary("NovaCore");
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        NovaCore.initialize();
    }

    private static final class NovaCore {
        static native void initialize();
    }
}
