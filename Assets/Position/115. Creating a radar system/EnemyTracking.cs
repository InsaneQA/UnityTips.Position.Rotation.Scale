using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    [SerializeField] private TrackedEnemy _enemy;

    private void Update()
    {
        Vector3 position = transform.InverseTransformPoint(_enemy.transform.position);
        Debug.Log("Local enemy position: " + position + ", Global position: " + _enemy.transform.position);
    }
}

