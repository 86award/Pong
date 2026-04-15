using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;
    private Vector2 _previousVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 RandomDirection()
    {

        float radians = Random.Range(-45f, 45f) * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        return new Vector2(x, y);
    }

    
    private void Start()
    {
        _rb.linearVelocity = RandomDirection().normalized * _speed;
    }

    private void FixedUpdate()
    {
        _previousVelocity = _rb.linearVelocity;
    }

    // the problem I was having: I wasn't caching the velocity before the impact
    // instead I was trying to reflect the angle using velocity AFTER the imapct
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.GetContact(0).normal;
        _rb.linearVelocity = Vector2.Reflect(_previousVelocity, collisionNormal);
    }
}