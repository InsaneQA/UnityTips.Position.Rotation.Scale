using System.Collections.Generic;
using UnityEngine;

public class RadarSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private RectTransform _center;
    [SerializeField] private EnemyContainer _enemyContainer;

    private float _centerRadius;

    private List<RectTransform> _dots = new List<RectTransform>();

    private void Awake()
    {
        _centerRadius = _center.sizeDelta.x / 2;
    }

    private void Start()
    {
        _dots = new List<RectTransform>(20);
        for (int i = 0; i < 20; i++)
        {
            var dot = Instantiate(_dotPrefab, _center);
            dot.SetActive(false);
            var dotRect = dot.GetComponent<RectTransform>();
            dotRect.SetParent(_center, worldPositionStays: false);
            _dots.Add(dotRect);
        }
    }

    private void Update()
    {
        foreach (var dot in _dots)
        {
            dot.gameObject.SetActive(false);
        }

        foreach (var enemy in _enemyContainer.Enemies)
        {
            AddEnemyToRadar(enemy);
        }
    }

    private void AddEnemyToRadar(TrackedEnemy enemy)
    {
        // Get an inactive dot
        var dot = _dots.Find(item => !item.gameObject.activeSelf);

        var enemyPositionRelatedToPlayer = _player.transform.InverseTransformPoint(enemy.transform.position);

        var scaleFactor = _centerRadius / _enemyContainer.ColliderRadius;
        var dotPosition = enemyPositionRelatedToPlayer * scaleFactor;
        PlaceDotOnUi(dot, dotPosition);

        //Activate the dot
        dot.gameObject.SetActive(true);
    }

    private void PlaceDotOnUi(RectTransform dot, Vector3 dotPosition)
    {
        dot.localPosition = dotPosition;
    }
}
