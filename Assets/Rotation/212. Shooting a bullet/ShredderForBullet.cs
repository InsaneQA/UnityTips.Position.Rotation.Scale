using UnityEngine;

public class ShredderForBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
