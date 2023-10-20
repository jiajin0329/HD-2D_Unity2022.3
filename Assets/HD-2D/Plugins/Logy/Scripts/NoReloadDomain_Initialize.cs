using UnityEngine;
using UnityEditor;

public class NoReloadDomain_ExitingPlayModeInitialize<T> : Cache {
    static bool _initializeEvent;
    protected override void Awake() {
        base.Awake();
        if(_initializeEvent)
            return;
        _initializeEvent = true;

        #if UNITY_EDITOR
        EditorApplication.playModeStateChanged += ExitingPlayModeInitializeEvent;
        #endif
    }

    #if UNITY_EDITOR
    void ExitingPlayModeInitializeEvent(PlayModeStateChange _stateChange) {
        if (_stateChange != PlayModeStateChange.ExitingPlayMode)
            return;
        
        ExitingPlayModeInitialize();

        EditorApplication.playModeStateChanged -= ExitingPlayModeInitializeEvent;
        Debug.Log($"{typeof(T).Name} Initialized");
    }
    #endif
    
    protected virtual void ExitingPlayModeInitialize() {
        _initializeEvent = false;
    }
}
