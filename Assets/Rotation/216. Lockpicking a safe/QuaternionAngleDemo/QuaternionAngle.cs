using UnityEngine;

public class QuaternionAngle : MonoBehaviour
{
    [SerializeField] private Transform _sphere1;
    [SerializeField] private Transform _sphere2;

    private void Update()
    {
        Debug.Log(Quaternion.Angle(_sphere1.rotation, _sphere2.rotation));
    }
}
