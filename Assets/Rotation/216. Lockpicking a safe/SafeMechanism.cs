using UnityEngine;

public class SafeMechanism : MonoBehaviour
{
    [SerializeField] private TextMesh _currentCylinder;
    [SerializeField] private Cylinder[] _cylinders;
    [SerializeField] private GameObject _isOpened;

    private AudioSource _audioSource;

    public bool IsOpened { get; private set; }

    public int CurrentCylinderIndex { get; private set; }

    private RotationCounter _rotationCounter;

    public Cylinder CurrentCylinder { get { return (CurrentCylinderIndex <= 1) ? _cylinders[0] : _cylinders[CurrentCylinderIndex - 1]; } }

    private void Start()
    {
        CurrentCylinderIndex = _cylinders.Length;
        _rotationCounter = GetComponent<RotationCounter>();

    }

    private void Update()
    {
        if (CurrentCylinderIndex < 1)
        {
            return;
        }
        _currentCylinder.text = "Current Cylinder: " + CurrentCylinderIndex.ToString();
    }

    public void MoveToNextCylinder()
    {
        if (CurrentCylinderIndex != 1)
        {
            CurrentCylinderIndex--;
            _rotationCounter.ClearRotation();
        }
        else
        {
            IsOpened = true;
            _isOpened.SetActive(IsOpened);
        }
    }
}

