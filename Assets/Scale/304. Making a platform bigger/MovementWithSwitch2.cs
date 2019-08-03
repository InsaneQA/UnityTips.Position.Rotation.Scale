using UnityEngine;

public class MovementWithSwitch2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _movementVector;
    private bool _canJump;
    private LookDirection _lookDirection;

    /// <summary>
    /// How do you want to implement the sprite switch?
    /// </summary>
    [SerializeField] private SwitchMethod _switchMethod;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingSpeed;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var movementVector = new Vector2(horizontalAxis * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = transform.TransformVector(movementVector);

        if (horizontalAxis < -0.01f)
        {
            SetDirection(LookDirection.Right);
        }

        if (horizontalAxis > 0.01f)
        {
            SetDirection(LookDirection.Left);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void SetDirection(LookDirection direction)
    {
        if (_lookDirection != direction)
        {
            _lookDirection = direction;
            SwitchSpriteDirection();
        }
    }

    private void SwitchSpriteDirection()
    {
        switch (_switchMethod)
        {
            // First method - rotate around Y axis
            case SwitchMethod.Rotate:
                _spriteRenderer.transform.Rotate(0, 180f, 0);
                return;

            // Second method - inverse the sprite
            case SwitchMethod.FlipX:
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                return;

            // Third method - scale the sprite by -1
            case SwitchMethod.Scale:
                var spriteLocalScale = _spriteRenderer.transform.localScale;
                _spriteRenderer.transform.localScale = new Vector3(-spriteLocalScale.x, spriteLocalScale.y, spriteLocalScale.z);
                return;
        }
    }

    private void Jump()
    {
        if (_canJump)
        {
            var jumpVector = new Vector2(0, _jumpingSpeed);
            jumpVector = transform.TransformVector(jumpVector);
            _rigidbody.velocity += jumpVector;
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

    private enum SwitchMethod
    {
        Rotate, FlipX, Scale
    }

    public enum LookDirection
    {
        Left,
        Right
    }
}

