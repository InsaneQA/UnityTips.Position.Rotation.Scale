using System.Collections;
using UnityEngine;

public class SloMo : MonoBehaviour
{
    private Recharge _recharge;
    [SerializeField] private float _sloMoScale;
    [SerializeField] private float _sloMoDuration;

    private void Awake()
    {
        _recharge = GetComponent<Recharge>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && _recharge.IsAvailable)
        {
            StartCoroutine(UseSloMo());
        }
    }

    private IEnumerator UseSloMo()
    {
        _recharge.UseSkill();
        Time.timeScale = _sloMoScale;

        yield return new WaitForSeconds(_sloMoDuration * _sloMoScale);

        while (Time.timeScale < 1)
        {
            Time.timeScale = (Time.timeScale + 0.1f > 1) ? 1f : Time.timeScale + 0.1f;
            yield return null;
        }

        _recharge.StartRecharging();
    }
}
