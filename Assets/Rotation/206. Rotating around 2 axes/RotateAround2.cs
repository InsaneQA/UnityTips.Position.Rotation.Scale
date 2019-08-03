using UnityEngine;

public class RotateAround2 : MonoBehaviour
{
    [SerializeField] private int _speed = 50;

    private void Update()
    {
        var rotationY = Quaternion.Euler(0, _speed * Time.deltaTime, 0);
        var rotationX = Quaternion.Euler(_speed * Time.deltaTime, 0, 0);
        transform.rotation *= rotationY;
        transform.rotation *= rotationX;
    }
}
