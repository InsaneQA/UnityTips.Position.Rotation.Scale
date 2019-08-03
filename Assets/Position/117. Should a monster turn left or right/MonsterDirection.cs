using UnityEngine;

public class MonsterDirection : MonoBehaviour
{
    private GridManager _gridManager;
    private RandomDirectionGenerator _randomDirectionGenerator;
    private PossibleDirections _currentDirection = 0;

    public PossibleDirections PossibleDirections { get; set; }
    public int PossibleDirectionsCount { get { return CountPossibleDirections(PossibleDirections); } }
    public PossibleDirections CurrentDirection
    {
        get
        {
            return _currentDirection;
        }
        set
        {
            _currentDirection = value;

            UpdateInverseValue();
            UpdateTargetPosition();
        }
    }

    private void UpdateTargetPosition()
    {
        TargetPosition = _gridManager.GetTargetPosition(CurrentDirection, TargetPosition, transform);
        RotateTowardsTargetPosition();
    }

    public PossibleDirections InverseDirection { get; set; }
    public Vector2 TargetPosition { get; set; }

    private void Start()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _randomDirectionGenerator = GetComponent<RandomDirectionGenerator>();
        TargetPosition = transform.position;
        CurrentDirection = PossibleDirections.Right;
    }

    private void UpdateInverseValue()
    {
        if (_currentDirection == PossibleDirections.Up)
        {
            InverseDirection = PossibleDirections.Down;
            return;
        }

        if (_currentDirection == PossibleDirections.Down)
        {
            InverseDirection = PossibleDirections.Up;
            return;
        }

        if (_currentDirection == PossibleDirections.Left)
        {
            InverseDirection = PossibleDirections.Right;
            return;
        }

        if (_currentDirection == PossibleDirections.Right)
        {
            InverseDirection = PossibleDirections.Left;
        }
    }

    public void SetRandomTargetPosition()
    {
        // Getting a random direction.
        CurrentDirection = _randomDirectionGenerator.GetRandomTargetDirection();
    }

    public void UpdateTheDirectionPossibilities(PossibleDirections directionToPlayer)
    {
        _randomDirectionGenerator.UpdateTheDirectionPossibilities(directionToPlayer);
    }

    public void GenerateDirectionPossibilities()
    {
        // We remove the Inverse direction from possible directions since we don't want to go there.
        var directionsToChoose = PossibleDirections ^ InverseDirection;
        _randomDirectionGenerator.GenerateDirectionPossibilities(directionsToChoose);
    }

    private void RotateTowardsTargetPosition()
    {
        Vector3 relativePosition = TargetPosition - (Vector2)transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, relativePosition);
    }

    public bool NewDirectionIsObvious()
    {
        var possibleDirectionsCount = CountPossibleDirections(PossibleDirections);

        // If there is as single path - go for it!
        if (possibleDirectionsCount.Equals(1))
        {
            CurrentDirection = PossibleDirections;
            return true;
        }

        // This line force the monster to not go back if there is another path (cuz why would he do that?..)
        if (possibleDirectionsCount.Equals(2))
        {
            CurrentDirection = PossibleDirections ^ InverseDirection;
            return true;
        }

        return false;
    }

    public bool MonsterReachedTargetPosition()
    {
        //return (TargetPosition.x - transform.position.x) < GridManager.Delta && (TargetPosition.y - transform.position.y) < GridManager.Delta;
        return (TargetPosition - (Vector2)transform.position).magnitude < GridManager.Delta;
    }

    public static int CountPossibleDirections(PossibleDirections directions)
    {
        var count = 0;

        if ((directions & PossibleDirections.Up) == PossibleDirections.Up)
        {
            count++;
        }

        if ((directions & PossibleDirections.Down) == PossibleDirections.Down)
        {
            count++;
        }

        if ((directions & PossibleDirections.Left) == PossibleDirections.Left)
        {
            count++;
        }

        if ((directions & PossibleDirections.Right) == PossibleDirections.Right)
        {
            count++;
        }

        return count;
    }
}

