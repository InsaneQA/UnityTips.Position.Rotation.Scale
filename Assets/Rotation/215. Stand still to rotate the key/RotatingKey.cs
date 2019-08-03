using UnityEngine;

public class RotatingKey : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 10f;
    [SerializeField] private Transform _key;
    [SerializeField] private GameObject _openedDoorLabel;

    private Quaternion _startRotation;
    private Quaternion _endRotation;
    private Quaternion _rotationStep;
    private float _rotationPercent = 0f;
    private bool _playerIsOnThePosition;
    private bool _unlocked = false;

    public bool Unlocked { get { return _unlocked; } }

    protected void Awake()
    {
        _startRotation = _key.transform.localRotation;
        _endRotation = _startRotation * Quaternion.Euler(120f, 90f, 0f);
        _rotationStep = Quaternion.Slerp(_startRotation, _endRotation, Time.deltaTime / _rotationDuration);
    }

    private void Update()
    {
        // The player is not on the position and the key has not been rotated - do nothing
        if (_key.transform.localRotation == _startRotation && !_playerIsOnThePosition)
        {
            return;
        }

        // THE DOOR IS UNLOCKED!
        if (_key.transform.localRotation == _endRotation)
        {
            _unlocked = true;
            enabled = false;
            _openedDoorLabel.gameObject.SetActive(true);
            return;
        }

        if (_playerIsOnThePosition)
        {
            _key.transform.localRotation *= _rotationStep;
        }
        else
        {
            _key.transform.localRotation *= Quaternion.Inverse(_rotationStep);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            _playerIsOnThePosition = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            _playerIsOnThePosition = false;
        }
    }
}

