using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{

    private List<TrackedEnemy> _enemyList = new List<TrackedEnemy>();
    private CircleCollider2D _circleCollider;

    public List<TrackedEnemy> Enemies { get { return _enemyList; } }
    public float ColliderRadius { get { return _circleCollider.radius; } }



    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<TrackedEnemy>();
        if (!_enemyList.Contains(enemy) && enemy != null) { _enemyList.Add(enemy); }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<TrackedEnemy>();
        if (enemy != null)
        {
            _enemyList.Remove(enemy);
        }
    }

    public void RemoveEnemy(TrackedEnemy enemy)
    {
        _enemyList.Remove(enemy);
    }
}

