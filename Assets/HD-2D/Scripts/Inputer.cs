using UnityEngine;
using System;

public class Inputer : MonoBehaviour {
    [field:ShowOnly][field:SerializeField] public Vector2 vector2 { get; protected set; }

    public Action InputDownEvent;
    public Action UpdateEvent;
}
