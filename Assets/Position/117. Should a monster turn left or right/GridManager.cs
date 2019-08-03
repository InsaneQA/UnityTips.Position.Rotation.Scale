using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private float _gridSize;

    public const float Delta = 0.08f;

    public float GridSize { get { return _gridSize; } }

    public bool IsObjectInsideTheGrid(Transform objectTransform)
    {
        var position = objectTransform.position;
        return ((position.x % _gridSize < Delta) && (position.y % _gridSize < Delta));
    }

    public Vector2 GetTargetPosition(PossibleDirections currentDirection, Vector2 currentTarget, Transform objectTransform)
    {
        switch (currentDirection)
        {
            case PossibleDirections.Up:
                return currentTarget + Vector2.up * _gridSize;
            case PossibleDirections.Down:
                return currentTarget + Vector2.down * _gridSize;
            case PossibleDirections.Left:
                return currentTarget + Vector2.left * _gridSize;
            case PossibleDirections.Right:
                return currentTarget + Vector2.right * _gridSize;
            default:
                throw new ArgumentException("No such direction exists!");
        }
    }
}

