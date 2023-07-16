using UnityEngine;
using System;
using System.Threading.Tasks;
using Logy;

[Serializable]
public class Move {
    [field:ShowOnly][field:SerializeField] public Vector2 moveVector2 { get; private set; }
    [field:ShowOnly][field:SerializeField] public float currentSpeedPercentage { get; private set; }
    [field:SerializeField] public Rigidbody rigidbody { get; private set; }
    [field:SerializeField] public byte speed { get; private set; }
    
    [SerializeField] float _secondsToMaxSpeed;
    [SerializeField] float _secondsToStop;
    
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

        SpeedUp();
        SpeedDown();

        if(Calculate.VectorDistance (moveVector2) > 1f) {
            moveVector2 = moveVector2.normalized;
        }

        rigidbody.velocity = speed * new Vector3(moveVector2.x, rigidbody.velocity.y, moveVector2.y);

        CalculatePublicVariable();

        await Task.Delay(0);
    }

    void SpeedDown() {
        float _currentSpeed = Calculate.VectorDistance(moveVector2);
        float _resultSpeed = _currentSpeed - (_speedDown * Time.deltaTime);

        _resultSpeed = _resultSpeed > 0 ? _resultSpeed : 0f;

        moveVector2 = _resultSpeed > 0 ? moveVector2 * _resultSpeed / _currentSpeed : Vector2.zero;
    }

    void SpeedUp() {
        moveVector2 += _speedUp * Time.deltaTime * _character.inputer.vector2;
    }

    void CalculatePublicVariable() {
        currentSpeedPercentage = Calculate.VectorDistance(new Vector2(rigidbody.velocity.x, rigidbody.velocity.z)) / speed;
    }
}
