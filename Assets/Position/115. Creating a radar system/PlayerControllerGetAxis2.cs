using UnityEngine;

public class PlayerControllerGetAxis2 : MonoBehaviour
{
    private MovementManager2 _movementManager;

    private void Start()
    {
        _movementManager = GetComponent<MovementManager2>();
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.red * 20);
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);
        movementVector *= _movementManager.Speed * Time.deltaTime;

        transform.Translate(movementVector);
    }
}

