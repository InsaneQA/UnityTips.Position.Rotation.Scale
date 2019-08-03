using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}
