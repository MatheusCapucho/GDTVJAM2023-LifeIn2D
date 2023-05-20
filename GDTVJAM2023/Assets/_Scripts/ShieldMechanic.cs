using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMechanic : MonoBehaviour
{
    [SerializeField]
    private float _shieldRechargeCooldown = 10f;

    private bool _isShieldDown;

    public static Action TookDamage;
    private void OnEnable()
    {
        TookDamage += OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        if(_isShieldDown)
        {
            Debug.Log("Game Over");
        } 
        else
        {
            _isShieldDown = true;
            StartCoroutine(RechargeShield());
        }
    }

    IEnumerator RechargeShield()
    {

        yield return new WaitForSeconds(_shieldRechargeCooldown);
        _isShieldDown = false;
    }
}
