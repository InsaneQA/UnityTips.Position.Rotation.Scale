using UnityEngine;

public class MovingPlatformRepeat : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Repeat(Time.time * _speed, _distance),
            transform.position.y,
            transform.position.z);
    }
}
