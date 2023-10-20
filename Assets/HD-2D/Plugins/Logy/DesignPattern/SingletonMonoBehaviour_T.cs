using UnityEngine;

public class SingletonMonoBehaviour<T> : NoReloadDomain_ExitingPlayModeInitialize<T> where T : SingletonMonoBehaviour<T> {
    static T _instance;
    public static T instance {
        get {
            if (_instance == null) {
                _instance = new GameObject().AddComponent<T>();
                _instance.gameObject.name = nameof(T);
                Debug.Log($"{typeof(T).Name} isn't pre-generated");
            }
            return _instance;
        }
    }

    protected override void Awake() {
        base.Awake();

        if (_instance != null) {
            Destroy(gameObject);
        }
        else {
            _instance = (T)this;
        }
    }

    protected virtual void OnDestroy() {
        if(_instance == this) {
            _instance = null;
        }
        Debug.Log($"{typeof(T).Name} {nameof(OnDestroy)}");
    }

    protected override void Initialize() {
        base.Initialize();

        if(_instance == this) {
            _instance = null;
        }
    }
}