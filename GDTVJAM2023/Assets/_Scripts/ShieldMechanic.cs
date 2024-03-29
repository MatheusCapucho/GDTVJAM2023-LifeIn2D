using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMechanic : MonoBehaviour
{
    [SerializeField]
    private float _shieldRechargeCooldown = 10f;
    [SerializeField]
    private float _shieldRechargeRate = 0.1f;

    public float ShieldRechargeCooldown => _shieldRechargeCooldown;
    public float ShieldRechargeRate => _shieldRechargeRate;

    private bool _isShieldDown;
    private Invulnerability _invulnerability;

    private Coroutine cr;

    public static Action TookDamage;

    private void Start()
    {
        _invulnerability = GetComponent<Invulnerability>();
    }

    private void OnEnable()
    {
        TookDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        TookDamage -= OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        if(_isShieldDown)
        {
            StartCoroutine(LoadMenu());         
        } 
        else
        {
            _isShieldDown = true;
            if(cr == null)
                cr = StartCoroutine(RechargeShield());
        }
    }

    IEnumerator LoadMenu()
    {
        MainMenu menu = FindAnyObjectByType<MainMenu>();

        FindAnyObjectByType<Timer>().StopTimer();

        yield return new WaitForSeconds(0.1f);
        menu.LoadSceneByIndex(2);
    }

    IEnumerator RechargeShield()
    {

        yield return new WaitForSeconds(_shieldRechargeCooldown);
        _isShieldDown = false;
        cr = null;
        yield return null;
    }
}
