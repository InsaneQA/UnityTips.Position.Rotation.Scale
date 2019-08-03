using UnityEngine;

public class PlayerForTurret : MonoBehaviour
{

    [SerializeField] private float _speed = 3f;

    // 
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.red * 20);
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);
        movementVector.Normalize();
        movementVector *= _speed * Time.deltaTime;

        transform.Translate(movementVector);
    }
}
