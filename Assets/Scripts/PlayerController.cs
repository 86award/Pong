using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputAction moveAction;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private bool _isAIControlled;

    [SerializeField]
    private float _aiMoveSpeed = 3f; // Slower than player speed

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions["Move"];
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = _rb.position;

        if (!_isAIControlled)
        {
            Vector2 inputValue = moveAction.ReadValue<Vector2>();
            float movement = inputValue.y * moveSpeed * Time.fixedDeltaTime;
            float clampedY = Mathf.Clamp(currentPos.y + movement, -3.75f, 3.75f);

            _rb.MovePosition(new Vector2(currentPos.x, clampedY));
        }
        else
        {
            Ball ball = FindAnyObjectByType<Ball>();
            if (ball != null)
            {
                float ballY = ball.transform.position.y;
                float targetY = Mathf.Clamp(ballY, -3.75f, 3.75f);
                
                // Move towards the ball at reduced speed
                float movement = Mathf.Clamp(targetY - currentPos.y, -_aiMoveSpeed * Time.fixedDeltaTime, _aiMoveSpeed * Time.fixedDeltaTime);
                float newY = currentPos.y + movement;

                _rb.MovePosition(new Vector2(currentPos.x, newY));
            }
        }
    }
}
