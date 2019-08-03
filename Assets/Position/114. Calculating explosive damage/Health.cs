using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoints;

    public float HealthPoints
    {
        get
        {
            return _healthPoints;
        }
        set
        {
            _healthPoints = (value >= 0) ? value : 0;
        }
    }
}

