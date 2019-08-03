using UnityEngine;

public class PlayerForSillyMonster : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private CollisionDetector _collisionDetector;

    private void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    private void Update()
    {
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");

        var movementVector = new Vector2(movementX, movementY);

        movementVector.Normalize();
        movementVector *= _speed * Time.deltaTime;

        if (!_collisionDetector.IsColliderAhead(movementVector))
        {
            transform.Translate(movementVector);
        }
    }
}

