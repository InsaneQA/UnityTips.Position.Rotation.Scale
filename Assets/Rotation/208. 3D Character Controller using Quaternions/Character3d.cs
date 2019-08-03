using UnityEngine;

public class Character3d : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [SerializeField] private int _speed = 5;

    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * _speed;
        mouseY += Input.GetAxis("Mouse Y") * _speed;
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        var rotationY = Quaternion.AngleAxis(mouseY, Vector3.left);
        var rotationX = Quaternion.AngleAxis(mouseX, Vector3.up);
        transform.rotation = rotationX * rotationY;
    }
}

