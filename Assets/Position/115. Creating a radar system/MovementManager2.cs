using UnityEngine;

public class MovementManager2 : MonoBehaviour
{

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _step = 10f;

    public float Speed { get { return _speed; } }

    public float Step { get { return _step; } }
}
