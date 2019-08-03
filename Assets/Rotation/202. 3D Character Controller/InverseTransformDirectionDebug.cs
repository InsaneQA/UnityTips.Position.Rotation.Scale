using UnityEngine;

public class InverseTransformDirectionDebug : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        Debug.Log(transform.InverseTransformDirection(Vector3.forward));
    }
}
