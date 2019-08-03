using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        transform.LookAt(_player);
    }
}
