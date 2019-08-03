using UnityEngine;

public class RotationCounter : MonoBehaviour
{
    private float _totalRotation = 0;

    [SerializeField] private TextMesh _rotationNumberText;
    [SerializeField] private TextMesh _totalRotationText;
    private bool _shouldClearRotation;
    private Vector3 lastPoint;

    private int _direction = 1;

    public int RotationNumber { get { return (int)(_totalRotation * _direction / 360); } }

    public void ClearRotation()
    {
        _shouldClearRotation = true;
    }

    public void SwitchDirection()
    {
        _direction *= -1;
    }

    private void Start()
    {
        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.z = 0;
    }

    private void Update()
    {
        Vector3 facing = transform.TransformDirection(Vector3.right);
        facing.z = 0;

        if (_shouldClearRotation)
        {
            _totalRotation = 0;
            _shouldClearRotation = false;
            lastPoint = facing;
            UpdateUi();
            return;

        }

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).z < 0)
        {
            angle *= -1;
        }

        _totalRotation += angle;
        lastPoint = facing;

        UpdateUi();
    }

    private void UpdateUi()
    {
        _totalRotationText.text = "Total Rotation: " + _totalRotation.ToString();
        _rotationNumberText.text = "Rotation Number: " + RotationNumber.ToString();
    }
}

