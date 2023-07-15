using UnityEngine;

public class Cache : MonoBehaviour {
    public new Transform transform { 
        get {
            if(_transform == null) {
                _transform = GetComponent<Transform>();
            }
            return _transform;
        }
        private set {}
    }
    Transform _transform;

    protected virtual void Awake() {
        if(_transform == null) {
            _transform = GetComponent<Transform>();
        }
    }
}
