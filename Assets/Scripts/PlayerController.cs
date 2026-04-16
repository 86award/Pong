using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputAction moveAction;

    [SerializeField]
    private float moveSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions["Move"];
    }

    private void FixedUpdate()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();
        Vector2 currentPos = _rb.position;

        // Calculate Y-axis movement with explicit Time.deltaTime for frame-rate independence
        float movement = inputValue.y * moveSpeed * Time.fixedDeltaTime;
        float clampedY = Mathf.Clamp(currentPos.y + movement, -3.75f, 3.75f);

        _rb.MovePosition(new Vector2(currentPos.x, clampedY));
    }
}
