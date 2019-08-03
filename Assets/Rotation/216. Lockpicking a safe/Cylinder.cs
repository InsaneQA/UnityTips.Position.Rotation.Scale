using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private int _cipherNumber;

    private float CipherNumberAngle { get { return 36f * _cipherNumber; } }

    private void Start()
    {
        transform.Rotate(Vector3.forward, CipherNumberAngle);
    }
}

