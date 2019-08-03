using TMPro;
using UnityEngine;

public class ShowHealth : MonoBehaviour
{
    private TextMeshPro _healthText;
    private Health _health;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        _healthText = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _healthText.text = _health.HealthPoints.ToString();
    }
}
