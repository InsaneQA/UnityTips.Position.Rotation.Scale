using UnityEngine;

public class ArrayRotation : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        _center.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }
}
