using UnityEngine;

public class ArrayCreator : MonoBehaviour
{
    [SerializeField] [Range(2, 6)] private int _itemCount;
    [SerializeField] private GameObject _center;
    [SerializeField] private float _distanceFromCenter;
    [SerializeField] private GameObject _starPrefab;

    private void Awake()
    {
        CreateRoundArray(_itemCount);
    }

    public void CreateRoundArray(int itemCount)
    {
        for (int i = 0; i < itemCount; i++)
        {
            var star = Instantiate(_starPrefab, _center.transform);
            star.GetComponent<RotateAroundCenter>().Center = _center;
            star.transform.Translate(new Vector2(_distanceFromCenter, 0));
            star.transform.RotateAround(_center.transform.position, Vector3.forward, (360.0f / itemCount) * i);
        }
    }
}

