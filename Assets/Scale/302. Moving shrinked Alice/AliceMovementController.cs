using UnityEngine;

public class AliceMovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 _movementVector;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingSpeed;
    [SerializeField] private JumpScript _jumpScript;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpScript = GetComponent<JumpScript>();
    }

    private void Update()
    {
        var movementVector = new Vector2(-Input.GetAxis("Horizontal") * _speed, 0);

        // Update the movementVector before updating velocity
        movementVector = transform.TransformVector(movementVector) + new Vector3(0, _rigidbody.velocity.y, 0);
        _rigidbody.velocity = movementVector;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_jumpScript.CanJump)
        {
            var jumpVector = new Vector3(0, _jumpingSpeed, 0);
            jumpVector = transform.TransformVector(jumpVector);
            _rigidbody.velocity += jumpVector;
        }
    }
}

