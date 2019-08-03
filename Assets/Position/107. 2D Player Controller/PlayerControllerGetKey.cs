using UnityEngine;

public class PlayerControllerGetKey : MonoBehaviour
{
    private MovementManager _movementManager;

    void Start()
    {
        _movementManager = GetComponent<MovementManager>();
    }


    void Update()
    {
        var movementVector = new Vector2();

        // Use Keycode enum...
        if (Input.GetKey(KeyCode.A)) { movementVector.x -= 1; }
        if (Input.GetKey(KeyCode.D)) { movementVector.x += 1; }

        // ...or the button name (lowercase!)
        if (Input.GetKey("s")) { movementVector.y -= 1; }
        if (Input.GetKey("w")) { movementVector.y += 1; }

        movementVector *= _movementManager.Speed * Time.deltaTime;

        transform.Translate(movementVector);
    }
}
