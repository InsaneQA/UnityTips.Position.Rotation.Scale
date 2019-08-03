using UnityEngine;

public class RadarGameManager : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;

    public void RemoveEnemy(TrackedEnemy enemy)
    {
        _enemyContainer.RemoveEnemy(enemy);
    }
}
