using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShield : MonoBehaviour
{

    private Slider _slider;
    private Coroutine coroutine = null;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        ShieldMechanic.TookDamage += StartSliderRefresh;
    }

    private void OnDisable()
    {
        ShieldMechanic.TookDamage -= StartSliderRefresh;
    }

    private void StartSliderRefresh()
    {
        if(coroutine == null)
            coroutine = StartCoroutine(ResetSlider());
    }

    IEnumerator ResetSlider()
    {
        ShieldMechanic mechanic = FindAnyObjectByType<ShieldMechanic>();
        var rechargeRate = mechanic.ShieldRechargeRate;
        var timeToRecharge = mechanic.ShieldRechargeCooldown;
        _slider.value = _slider.minValue;
        _slider.maxValue = timeToRecharge;
        while(_slider.value < _slider.maxValue)
        {
            _slider.value += rechargeRate;
            yield return new WaitForSeconds(rechargeRate);
        }
        coroutine = null;
    }
}
