using UnityEngine;

public class PlayerController2d3 : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);

        movementVector.Normalize();
        movementVector *= _speed * Time.deltaTime;

        transform.Translate(new Vector3(movementVector.x, movementVector.y, 0), Space.World);
    }
}
