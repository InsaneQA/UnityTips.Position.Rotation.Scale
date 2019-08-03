using UnityEngine;

public class MovingPlatformPingPong2 : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * _speed, _distance), transform.position.y, transform.position.z);
    }
}

