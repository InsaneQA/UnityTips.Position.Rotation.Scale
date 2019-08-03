using UnityEngine;

public class JumpingBox : MonoBehaviour
{
    [SerializeField] private float _upVelocity;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = new Vector3(0, _upVelocity, 0);
    }
}
