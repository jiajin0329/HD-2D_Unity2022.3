using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inputer : Inputer {
    public void Input(InputAction.CallbackContext ctx) {
        vector2 = ctx.ReadValue<Vector2>();
    }

    void Update() {
        UpdateEvent?.Invoke();
    }
}
