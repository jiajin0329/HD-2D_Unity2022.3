using UnityEngine;
using System.Threading.Tasks;

public class Animator {
    [SerializeField] UnityEngine.Animator _animator;
    Character _character;

    public async void Initialize(Character _character) {
        this._character = _character;

        await Task.Delay(0);
    }

    async void Update() {

        await Task.Delay(0);
    }

    async void AnimationControl() {

        await Task.Delay(0);
    }
}
