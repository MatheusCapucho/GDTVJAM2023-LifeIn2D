using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : MonoBehaviour
{
    public static Action ChangeMap;

    [SerializeField]
    private float _changerCooldown = 10f;
    private float _timeElapsed = 0f;

    private bool _playTransition1 = false;


    private void OnEnable()
    {
        ChangeMap += OnChangeMap;
    }
    private void OnDisable()
    {
        ChangeMap -= OnChangeMap;
    }

    private void OnChangeMap()
    {
        _playTransition1 = !_playTransition1;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.K) && _timeElapsed > _changerCooldown)
        {
            _timeElapsed = 0f;
            ChangeMap?.Invoke();
            MapChangerAnimation.MapChanged?.Invoke();
        }
    }



}
