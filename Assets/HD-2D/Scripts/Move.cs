using UnityEngine;
using System;
using System.Threading.Tasks;
using Logy;

[Serializable]
public class Move {
    [field:ShowOnly][field:SerializeField] public Vector2 moveVector2 { get; private set; }
    [field:ShowOnly][field:SerializeField] public float currentSpeedPercentage { get; private set; }
    [SerializeField] byte _speed;
    [SerializeField] float _secondsToMaxSpeed;
    [SerializeField] float _secondsToStop;
    [SerializeField] Rigidbody _rigidbody;
    
    float _speedUp;
    float _speedDown;
    Character _character;

    public async void Initialize(Character _character) {
        this._character = _character;
        _speedDown = 1f / _secondsToStop;
        _speedUp = (1f / _secondsToMaxSpeed) + _speedDown;
        _character.inputer.UpdateEvent += Main;

        await Task.Delay(0);
    }

    async void Main() {
        if(_character.inputer.vector2 == Vector2.zero && moveVector2 == Vector2.zero) return;

        await SpeedUp();
        await SpeedDown();

        if(Calculate.VectorDistance (moveVector2) > 1f) {
            moveVector2 = moveVector2.normalized;
        }

        _rigidbody.velocity = _speed * new Vector3(moveVector2.x, _rigidbody.velocity.y, moveVector2.y);

        if(_rigidbody.velocity == Vector3.zero) return;

        await Direction();

        CalculatePublicVariable();

        await Task.Delay(0);
    }

    async Task SpeedDown() {
        float _currentSpeed = Calculate.VectorDistance(moveVector2);
        float _resultSpeed = _currentSpeed - (_speedDown * Time.deltaTime);

        _resultSpeed = _resultSpeed > 0 ? _resultSpeed : 0f;

        moveVector2 = _resultSpeed > 0 ? moveVector2 * _resultSpeed / _currentSpeed : Vector2.zero;

        await Task.Delay(0);
    }

    async Task SpeedUp() {
        moveVector2 += _speedUp * Time.deltaTime * _character.inputer.vector2;

        await Task.Delay(0);
    }

    async Task Direction() {
        bool _isRight = _rigidbody.velocity.x > 0;

        Vector3 _localAngles = _character.spriteRenderer.transform.localEulerAngles;

        if(_character.spriteRenderer.flipX == _isRight) return;

        _character.spriteRenderer.flipX = _isRight;

        await Task.Delay(0);
    }

    async void CalculatePublicVariable() {
        currentSpeedPercentage = Calculate.VectorDistance(new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z)) / _speed;

        await Task.Delay(0);
    }
}
