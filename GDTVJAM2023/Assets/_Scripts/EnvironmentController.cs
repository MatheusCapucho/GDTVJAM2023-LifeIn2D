using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    private GameObject _mainScene;
    private GameObject _parallelScene;
    private void Awake()
    {
        _mainScene = transform.GetChild(0).gameObject;
        _parallelScene = transform.GetChild(1).gameObject;
        _parallelScene.SetActive(false);
    }
    private void OnEnable()
    {
        MapChanger.ChangeMap += OnMapChange;
    }
    private void OnDisable()
    {
        MapChanger.ChangeMap -= OnMapChange;
    }

    private void OnMapChange()
    {
        if(_mainScene.activeInHierarchy)
        {
            _mainScene.SetActive(false);
            _parallelScene.SetActive(true);
        } 
        else
        { 
            _mainScene.SetActive(true);
            _parallelScene.SetActive(false);
            
        }
    }
}
