using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;

    private CircleCollider2D _bombCollider;
    private readonly List<Health> _affectedCharacters = new List<Health>();

    public void Explode()
    {
        foreach (var item in _affectedCharacters)
        {
            if (IsItemCoveredWithWall(item))
            {
                continue;
            }

            item.HealthPoints -= CalculateDamage(item.transform);
        }
    }

    private void Start()
    {
        _bombCollider = GetComponent<CircleCollider2D>();
        _bombCollider.radius = _explosionRadius;
    }

    private bool IsItemCoveredWithWall(Health item)
    {
        var layerMask = LayerMask.GetMask("Wall");
        var direction = item.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

        // If there is a wall between the item and the explosion - return true
        return (hit.collider != null);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var healthComponent = collider.gameObject.GetComponent<Health>();

        if (healthComponent != null)
        {
            _affectedCharacters.Add(healthComponent);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var healthComponent = collider.gameObject.GetComponent<Health>();

        if (healthComponent != null)
        {
            _affectedCharacters.Remove(healthComponent);
        }
    }

    private int CalculateDamage(Transform targetTransform)
    {
        var distance = Vector3.Distance(targetTransform.position, transform.position);

        if (distance > _explosionRadius)
        {
            return 0;
        }

        return (int)((1 - distance / _explosionRadius) * (_maxDamage - _minDamage) + _minDamage);
    }
}

