using UnityEngine;

[ExecuteInEditMode]
public class DrawLine : MonoBehaviour
{
    private void Update()
    {
        Debug.DrawLine(transform.position, Vector3.up, Color.red);
        Debug.DrawRay(transform.position, Vector3.up, Color.green);
    }
}
