using UnityEngine;
using UnityEditor;

public class NoReloadDomain_Initialize<T> : Cache {
    static bool _initializeEvent;
    protected override void Awake() {
        base.Awake();
        if(_initializeEvent)
            return;
        _initializeEvent = true;
        #if UNITY_EDITOR
        EditorApplication.playModeStateChanged += InitializeEvent;
        #endif
    }

    #if UNITY_EDITOR
    void InitializeEvent(PlayModeStateChange _stateChange) {
        if (_stateChange != PlayModeStateChange.ExitingEditMode)
            return;
        
        Initialize();

        EditorApplication.playModeStateChanged -= InitializeEvent;
        Debug.Log($"{typeof(T).Name} Initialized");
    }
    #endif
    
    protected virtual void Initialize() {
        _initializeEvent = false;
    }
}
