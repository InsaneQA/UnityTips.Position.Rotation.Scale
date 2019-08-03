using UnityEngine;

public class TimeRelatedPingPongBox : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, 3), transform.position.z);
    }
}
