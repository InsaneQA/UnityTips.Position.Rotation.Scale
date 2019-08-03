using UnityEngine;

public class PlayerControllerGetButtonDown : MonoBehaviour
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
        if (Input.GetButtonDown("Left")) { movementVector.x -= 1; }
        if (Input.GetButtonDown("Right")) { movementVector.x += 1; }

        // down and up
        if (Input.GetButtonDown("Down")) { movementVector.y -= 1; }
        if (Input.GetButtonDown("Up")) { movementVector.y += 1; }

        movementVector *= _movementManager.Speed * _movementManager.Step * Time.deltaTime;
        transform.Translate(movementVector);
    }
}

