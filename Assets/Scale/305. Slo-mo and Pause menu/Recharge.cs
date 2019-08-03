using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Recharge : MonoBehaviour
{
    [SerializeField] private float _rechargeTime;
    [SerializeField] private Image _clockMask;

    private float _timePassed;

    public bool IsAvailable { get; private set; }

    private void Awake()
    {
        IsAvailable = true;
    }

    public void UseSkill()
    {
        IsAvailable = false;
        _clockMask.fillAmount = 1f;
    }

    internal void StartRecharging()
    {
        StartCoroutine(RechargeSkill());
    }

    private IEnumerator RechargeSkill()
    {
        _timePassed = 0;

        while (_timePassed < _rechargeTime)
        {
            _timePassed += Time.deltaTime;
            _clockMask.fillAmount = 1f - _timePassed / _rechargeTime;
            yield return null;
        }

        IsAvailable = true;
    }
}
