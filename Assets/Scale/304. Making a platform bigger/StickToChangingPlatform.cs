using UnityEngine;

public class StickToChangingPlatform : MonoBehaviour
{
    [SerializeField] private MovementWithSwitch2 _player;

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
            var growingPlatform = collision.collider.GetComponent<GrowingPlatform>();
            if (growingPlatform != null)
            {
                collision.collider.GetComponent<GrowingPlatform>().AddChild(_player.transform);
            }
            else
            {
                _player.transform.parent = collision.transform;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            var growingPlatform = collision.collider.GetComponent<GrowingPlatform>();
            if (growingPlatform != null)
            {
                collision.collider.GetComponent<GrowingPlatform>().RemoveChild(_player.transform);
            }
            else
            {
                _player.transform.parent = null;
            }
        }
    }
}
