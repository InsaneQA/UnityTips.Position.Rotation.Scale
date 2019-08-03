using UnityEngine;

public class FigureGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _figurePrefab;
    [SerializeField] private ConveyorLine _conveyorLine;
    [SerializeField] private float _nextCreationTime = 2f;
    [SerializeField] private Transform _start;
    private float _currentTime;

    private void Start()
    {
        _currentTime = Time.time;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _nextCreationTime)
        {
            CreateFigure();
            _currentTime = 0f;
        }
    }

    public void CreateFigure()
    {
        var instance = Instantiate(_figurePrefab, _start.position, transform.rotation);
        var figure = instance.GetComponent<Figure>();
        _conveyorLine.AddObject(figure);
    }
}
