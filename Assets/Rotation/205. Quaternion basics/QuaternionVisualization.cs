using UnityEngine;

[ExecuteInEditMode]
public class QuaternionVisualization : MonoBehaviour
{
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 100, Color.green);
        Debug.DrawRay(transform.position, -transform.up * 100, Color.green);
    }
}
