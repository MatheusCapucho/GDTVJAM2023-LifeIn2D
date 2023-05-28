using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChangerAnimation : MonoBehaviour
{
    private Animator anim;

    private Action MapChanged;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        MapChanged += ChangeMap;
    }
    private void OnDisable()
    {
        MapChanged -= ChangeMap;
    }

    private void ChangeMap()
    {
        anim.SetTrigger("ChangeMap");
    }
}
