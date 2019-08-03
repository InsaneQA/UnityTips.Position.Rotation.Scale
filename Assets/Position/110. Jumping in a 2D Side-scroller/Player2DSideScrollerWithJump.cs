using UnityEngine;

public class Player2DSideScrollerWithJump : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movementVector;
    private bool _canJump;


    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_canJump)
        {
            _rigidbody.velocity += Vector2.up * _jumpSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            _canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            _canJump = false;
        }
    }
}
