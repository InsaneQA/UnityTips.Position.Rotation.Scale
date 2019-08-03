using UnityEngine;

public class ShowMethodResults : MonoBehaviour
{
    [SerializeField] private Transform _alice;

    [SerializeField] private TextMesh _transformDirection;
    [SerializeField] private TextMesh _transformPoint;
    [SerializeField] private TextMesh _transformVector;

    private Vector3 testVector = new Vector3(1, 1, 1);

    private void Update()
    {
        _transformDirection.text = "transformDirection:\t\t" + _alice.TransformDirection(testVector).ToString();
        _transformPoint.text = "transformPoint:\t\t" + _alice.TransformPoint(testVector).ToString();
        _transformVector.text = "transformVector:\t\t" + _alice.TransformVector(testVector).ToString();
    }
}
