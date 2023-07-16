using UnityEngine;
using System.Threading.Tasks;
using System;
using Logy;


[Serializable]
public class Animator {
    enum Direction {up, down, left, right}
    [ShowOnly][SerializeField]Direction _direction = Direction.down;
    [SerializeField] UnityEngine.Animator _animator;
    Character _character;

    public async void Initialize(Character _character) {
        this._character = _character;
        _character.inputer.UpdateEvent += Main;

        await Task.Delay(0);
    }

    async void Main() {
        JudgeDirection();
        AnimationControl();

        await Task.Delay(0);
    }

    void AnimationControl() {
        //set flipX
        bool _flipX = _direction == Direction.left;
        if(_character.spriteRenderer.flipX != _flipX) {
            _character.spriteRenderer.flipX = _flipX;
        }
        
        if(_character.move.currentSpeedPercentage > 0f) {
            if(_direction == Direction.right || _direction == Direction.left) {
                _animator.Play("walk_side");
            }
            else if(_direction == Direction.up) {
                _animator.Play("walk_up");
            }
            else {
                _animator.Play("walk_down");
            }
        }
        else {
            if(_direction == Direction.right || _direction == Direction.left) {
                _animator.Play("idle_side");
            }
            else if(_direction == Direction.up) {
                _animator.Play("idle_up");
            }
            else {
                _animator.Play("idle_down");
            }
        }

        _animator.speed = _character.move.currentSpeedPercentage;
    }

    void JudgeDirection() {
        if(_character.inputer.vector2 == Vector2.zero) return;

        if(Mathf.Abs(_character.move.moveVector2.y) < 0.707f) {
            if(_character.move.moveVector2.x > 0f) {
                _direction = Direction.right;
            }
            else if(_character.move.moveVector2.x != 0f) {
                _direction = Direction.left;
            }
        }
        else {
            if(_character.move.moveVector2.y > 0f) {
                _direction = Direction.up;
            }
            else if(_character.move.moveVector2.y != 0f) {
                _direction = Direction.down;
            }
        }
    }
}
