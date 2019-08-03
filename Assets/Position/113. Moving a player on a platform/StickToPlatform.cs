using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public bool ShouldStick
    {
        get
        {
            return _rigidbody.velocity.y <= 0;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground") || ShouldStick)
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            transform.parent = null;
        }
    }
}
