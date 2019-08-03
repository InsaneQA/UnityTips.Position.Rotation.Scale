using UnityEngine;

public class PlayerControllerGetAxis : MonoBehaviour
{
    private MovementManager _movementManager;

    void Start()
    {
        _movementManager = GetComponent<MovementManager>();
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.red * 20);
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);
        movementVector *= _movementManager.Speed * Time.deltaTime;

        transform.Translate(movementVector);
    }
}

