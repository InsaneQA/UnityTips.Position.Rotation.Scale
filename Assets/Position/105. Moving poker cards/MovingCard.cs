using UnityEngine;

public class MovingCard : MonoBehaviour
{
    public Vector3 TargetPosition { set; get; }
    [SerializeField] private float _speed;

    public bool IsMoving { get; set; }

    private void Awake()
    {
        _speed = (_speed.Equals(0)) ? 1f : _speed;
    }

    void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _speed * Time.deltaTime);
        }
    }
}
