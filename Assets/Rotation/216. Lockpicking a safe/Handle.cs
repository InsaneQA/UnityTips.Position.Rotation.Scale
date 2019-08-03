using UnityEngine;

internal class Handle : MonoBehaviour
{
    private RotationCounter _rotationCounter;
    private SafeMechanism _safeMechanism;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rotationCounter = GetComponent<RotationCounter>();
        _safeMechanism = GetComponent<SafeMechanism>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveHandle();

        if (_rotationCounter.RotationNumber == _safeMechanism.CurrentCylinderIndex + 1)
        {
            TrackHandleNumber();
        }
    }

    private void MoveHandle()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, 36f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -36f);
        }
    }

    private void TrackHandleNumber()
    {
        var absRotationVector = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        var angleBetweenRotations = Quaternion.Angle(_safeMechanism.CurrentCylinder.transform.rotation, absRotationVector);
        if (angleBetweenRotations < 5)
        {
            _audioSource.Play();
            _safeMechanism.MoveToNextCylinder();
            _rotationCounter.SwitchDirection();
        }
    }
}
