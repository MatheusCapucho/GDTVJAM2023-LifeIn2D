using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChangerAnimation : MonoBehaviour
{
    private Animator anim;

    public static Action MapChanged;
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
        bool isParallel = !anim.GetBool("isParallel");
        anim.SetBool("isParallel", isParallel);
    }
}
