using UnityEngine;

internal class SpaceshipController3d : MonoBehaviour
{
    [SerializeField] private int _speed = 5;

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * _speed;
        var mouseY = -Input.GetAxis("Mouse Y") * _speed;

        var rotationY = Quaternion.AngleAxis(mouseY, Vector3.left);
        var rotationX = Quaternion.AngleAxis(mouseX, Vector3.up);
        transform.rotation *= rotationX * rotationY;
    }
}

