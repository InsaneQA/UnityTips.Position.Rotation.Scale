using UnityEngine;

public class PlayerControllerGetButton : MonoBehaviour
{
    private MovementManager _movementManager;

    private void Start()
    {
        _movementManager = GetComponent<MovementManager>();
    }

    private void Update()
    {
        var movementVector = new Vector2();

        // Left and right...
        if (Input.GetButton("Left")) { movementVector.x -= 1; }
        if (Input.GetButton("Right")) { movementVector.x += 1; }

        // down and up
        if (Input.GetButton("Down")) { movementVector.y -= 1; }
        if (Input.GetButton("Up")) { movementVector.y += 1; }

        movementVector *= _movementManager.Speed * Time.deltaTime;
        transform.Translate(movementVector);
    }
}

