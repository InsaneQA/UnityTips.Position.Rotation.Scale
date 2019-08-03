using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private int _speed = 50;

    private void Update()
    {
        var rotationY = Quaternion.Euler(0, _speed * Time.deltaTime, 0);
        transform.rotation *= rotationY;
    }
}
