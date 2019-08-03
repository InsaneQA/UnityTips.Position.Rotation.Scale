using UnityEngine;

public class MovingCard2 : MonoBehaviour
{
    public Vector3 TargetPosition { set; get; }
    public Vector3 InitialPosition { set; get; }
    private float _completedPath = 0;

    [SerializeField] private float _desiredArrivalTime;

    public bool IsMoving { get; set; }

    private void Awake()
    {
        _desiredArrivalTime = (_desiredArrivalTime.Equals(0)) ? 1f : _desiredArrivalTime;
    }

    private void Update()
    {
        if (IsMoving)
        {
            _completedPath += Mathf.Clamp01(Time.deltaTime / _desiredArrivalTime);

            // Correct Slerp usage.
            transform.position = Vector3.Lerp(InitialPosition, TargetPosition, _completedPath);

            // Incorrect Slerp usage.
            //transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime);

            if (_completedPath.Equals(1))
            {
                IsMoving = false;
            }
        }
    }
}
