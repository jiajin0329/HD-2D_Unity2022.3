using UnityEngine;

namespace Logy {
    public struct Calculate {
        public static float VectorDistance(Vector2 _vector2) {
            return Mathf.Sqrt(_vector2.x * _vector2.x + _vector2.y * _vector2.y);
        }

        public static float VectorDistanceNoSqrt(Vector2 _vector2) {
            return _vector2.x * _vector2.x + _vector2.y * _vector2.y;
        }
    }
}