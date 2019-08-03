using UnityEngine;

public class PlayerController2d2 : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.red * 20);
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);

        //Here we normalize the vector
        // This is the same as the following line:
        // movementVector = novementVector.normalized;
        movementVector.Normalize();
        movementVector *= _speed * Time.deltaTime;

        transform.Translate(movementVector);
    }
}
