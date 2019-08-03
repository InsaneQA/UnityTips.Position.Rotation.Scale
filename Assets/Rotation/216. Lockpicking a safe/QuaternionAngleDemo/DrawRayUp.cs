using UnityEngine;

[ExecuteInEditMode]
public class DrawRayUp : MonoBehaviour
{
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 10, Color.green);
    }
}
