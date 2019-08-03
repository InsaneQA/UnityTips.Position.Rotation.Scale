using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        var forward = -Input.GetAxis("Vertical");

        var movementVelocity = new Vector3(0, 0, forward);
        _rigidbody.velocity = transform.TransformDirection(movementVelocity) * _speed;
    }
}
