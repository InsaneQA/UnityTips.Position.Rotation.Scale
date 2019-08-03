using UnityEngine;

public class InverseTransformDirection : MonoBehaviour
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
        transform.rotation = rotationY;
        var rotationX = Quaternion.AngleAxis(mouseX, transform.InverseTransformDirection(Vector3.up));
        transform.rotation *= rotationX;
    }
}

