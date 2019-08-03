using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private float _circleColliderRadius;

    private void Awake()
    {
        var _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleColliderRadius = _circleCollider2D.radius;
    }

    public bool IsColliderAhead(Vector2 movementVector)
    {
        var rayDistance = movementVector.magnitude + _circleColliderRadius;
        var hit = Physics2D.Raycast(transform.position, movementVector, rayDistance);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return CheckPerpendicularCollisions(movementVector);
        }

    }

    private bool CheckPerpendicularCollisions(Vector2 movementVector)
    {
        var xVector = new Vector2(movementVector.x, 0);
        var yVector = new Vector2(0, movementVector.y);

        var xhit = Physics2D.Raycast(transform.position, xVector, _circleColliderRadius);

        if (xhit.collider != null)
        {
            return true;
        }

        var yhit = Physics2D.Raycast(transform.position, yVector, _circleColliderRadius);

        return yhit.collider != null;


    }
}
