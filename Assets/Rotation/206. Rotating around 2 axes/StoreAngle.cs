using UnityEngine;

public class StoreAngle : MonoBehaviour
{
    private float _angle = 0;

    [SerializeField] private float xSpeed = 50;
    [SerializeField] private float ySpeed = 50;

    private void Update()
    {
        _angle++;

        var rotationX = Quaternion.Euler(_angle * xSpeed, 0, 0);
        var rotationY = Quaternion.Euler(0, _angle * ySpeed, 0);
        //transform.rotation = rotationX * rotationY; // Not the right order!
        transform.rotation = rotationY * rotationX; // Correct order
    }
}
