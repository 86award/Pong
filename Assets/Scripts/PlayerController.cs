using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveUp;

    private void Awake()
    {
        moveUp = InputSystem.actions.FindAction("Move");

        moveUp.started += MoveUp_started;
    }

    private void MoveUp_started(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
    }
}
