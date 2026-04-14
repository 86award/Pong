using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputAction moveAction;

    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();
        Vector2 currentPos = _rb.position;
        
        // Calculate Y-axis movement with explicit Time.deltaTime for frame-rate independence
        float movement = inputValue.y * moveSpeed * Time.fixedDeltaTime;
        
        _rb.MovePosition(currentPos + new Vector2(0, movement));
    }
}
