using UnityEngine;

public class Player2DSideScroller : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // 
    private void Update()
    {
        var valueX = Input.GetAxis("Horizontal");
        var movementVector = new Vector2(valueX * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = movementVector;
    }
}
