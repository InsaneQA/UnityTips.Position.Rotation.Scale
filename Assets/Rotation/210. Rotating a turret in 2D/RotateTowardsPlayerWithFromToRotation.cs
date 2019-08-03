using UnityEngine;

public class RotateTowardsPlayerWithFromToRotation : MonoBehaviour
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
        var lookRotation = Quaternion.FromToRotation(Vector2.up, relativePosition);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}
