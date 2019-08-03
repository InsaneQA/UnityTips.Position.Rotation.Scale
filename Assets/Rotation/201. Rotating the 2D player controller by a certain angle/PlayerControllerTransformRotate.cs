using UnityEngine;

public class PlayerControllerTransformRotate : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        var rotationAngle = -Input.GetAxis("Horizontal");
        var movement = Input.GetAxis("Vertical");

        var movementVector = new Vector3(0, movement);

        transform.Rotate(0, 0, rotationAngle * _rotationSpeed);
        transform.Translate(movementVector * _movementSpeed * Time.deltaTime);
    }
}

