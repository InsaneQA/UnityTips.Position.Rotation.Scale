using UnityEngine;

public class MonsterTeleport : MonoBehaviour
{
    [SerializeField] private Transform _initialPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var monsterDirection = collider.GetComponent<MonsterDirection>();
        monsterDirection.transform.position = _initialPosition.position;
        monsterDirection.CurrentDirection = PossibleDirections.Right;
        monsterDirection.TargetPosition = _initialPosition.position;
    }
}
