using TMPro;
using UnityEngine;

public class SillyMazeMonster : MonoBehaviour
{
    private PlayerInMaze _player;
    private MonsterDirection _monsterDirection;

    [SerializeField] private float _speed;
    [SerializeField] private TextMeshPro _playerDirectionLabel;

    public PlayerInMaze Target { get; set; }

    public void Start()
    {
        _player = FindObjectOfType<PlayerInMaze>();
        _monsterDirection = GetComponent<MonsterDirection>();
    }

    public void Update()
    {
        var target = _monsterDirection.TargetPosition;

        if (_monsterDirection.MonsterReachedTargetPosition())
        {
            SelectNewDirectionToMove();
        }

        MoveTowardsTheTargetPosition();
    }

    private void SelectNewDirectionToMove()
    {
        GetPossibleDirections();

        if (_monsterDirection.NewDirectionIsObvious())
        {
            return;
        }

        _monsterDirection.GenerateDirectionPossibilities();


        if (IsPlayerAtTheSide())
        {
            var playerSide = FindThePlayerSide();
            var playerDirection = TransformVectorToDirection(playerSide);
            _monsterDirection.UpdateTheDirectionPossibilities(playerDirection);
        }

        _monsterDirection.SetRandomTargetPosition();
    }

    private PossibleDirections TransformVectorToDirection(Vector2 vector)
    {
        if (vector == Vector2.up)
        {
            return PossibleDirections.Up;
        }

        if (vector == Vector2.down)
        {
            return PossibleDirections.Down;
        }

        if (vector == Vector2.left)
        {
            return PossibleDirections.Left;
        }
        else
        {
            return PossibleDirections.Right;
        }
    }

    private Vector2 FindThePlayerSide()
    {
        var vectorToPlayer = _player.transform.position - transform.position;
        var crossVector = Vector3.Cross(transform.forward, vectorToPlayer);
        var dotProduct = Vector3.Dot(transform.up, crossVector);
        if (dotProduct > 0)
        {
            _playerDirectionLabel.text = "Player is at the left side!";
            return -transform.right;
        }
        else
        {
            _playerDirectionLabel.text = "Player is at the right side!";
            return transform.right;
        }
    }

    private bool IsPlayerAtTheSide()
    {
        var dotProduct = Vector2.Dot(transform.up, _player.transform.position - transform.position);
        return Mathf.Abs(dotProduct) <= GridManager.Delta;
    }

    private void GetPossibleDirections()
    {
        // Clear the previous possible directions
        _monsterDirection.PossibleDirections = 0;

        RaycastToDirectionToFindWall(Vector2.up, PossibleDirections.Up);
        RaycastToDirectionToFindWall(Vector2.down, PossibleDirections.Down);
        RaycastToDirectionToFindWall(Vector2.right, PossibleDirections.Right);
        RaycastToDirectionToFindWall(Vector2.left, PossibleDirections.Left);
    }

    private void RaycastToDirectionToFindWall(Vector3 rayDirection, PossibleDirections movementDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, 1.0f);
        if (hit.collider == null)
        {
            _monsterDirection.PossibleDirections = _monsterDirection.PossibleDirections | movementDirection;
        }
        else if (!hit.transform.tag.Equals("Wall"))
        {
            _monsterDirection.PossibleDirections = _monsterDirection.PossibleDirections | movementDirection;
        }
    }

    private void MoveTowardsTheTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, _monsterDirection.TargetPosition, _speed * Time.deltaTime);
    }
}

