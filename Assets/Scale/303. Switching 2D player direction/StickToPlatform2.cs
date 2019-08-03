using UnityEngine;

public class StickToPlatform2 : MonoBehaviour
{
    [SerializeField] private MovementWithSwitch _player;

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
        _rigidbody = _player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground") || ShouldStick)
        {
            _player.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            _player.transform.parent = null;
        }
    }
}
