using UnityEngine;

public class RotateTowardsPlayerWithLookRotation : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private float _rotationSpeed = 5;

    private void Start()
    {
        _player = FindObjectOfType<PlayerForTurret>().transform;
    }

    private void Update()
    {
        var relativePosition = _player.position - transform.position;
        var lookRotation = Quaternion.LookRotation(Vector3.forward, relativePosition);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}

