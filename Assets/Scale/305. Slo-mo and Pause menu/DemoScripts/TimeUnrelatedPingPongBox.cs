using UnityEngine;

public class TimeUnrelatedPingPongBox : MonoBehaviour
{
    private float _count;

    private void Update()
    {
        _count++;
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(_count * 0.1f, 3), transform.position.z);
    }
}
