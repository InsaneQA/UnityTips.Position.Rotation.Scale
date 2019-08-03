using UnityEngine;

public class TransformEuler : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private Transform _camera;
    float mouseX;
    float mouseY;

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * _speed;
        mouseY += Input.GetAxis("Mouse Y") * _speed;
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        _camera.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
