using UnityEngine;

public class Character : MonoBehaviour {
    [field:SerializeField] public Inputer inputer { get; private set; }
    [field:SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field:SerializeField] public Move move { get; private set; }
    

    void Start() {
        move.Initialize(this);
    }
}
