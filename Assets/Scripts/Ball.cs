using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private float RandomDirection()
    {
        return Random.Range(45f, 135f);
    }
    // give the ball a starting direction and speed
    private void Start()
    {
        _rb.linearVelocity = new Vector2(2, 2);
    }

    // when the ball hits an object it needs to reflect off

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.linearVelocity = new Vector2(_speed * Mathf.Sign(_rb.linearVelocityX) + _rb.linearVelocityX,
                                         _speed * Mathf.Sign(_rb.linearVelocityY) + _rb.linearVelocityY);
    }
}