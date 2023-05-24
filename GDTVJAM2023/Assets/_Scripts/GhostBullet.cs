using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBullet : Bullet
{
    private void OnEnable()
    {
        MapChanger.ChangeMap += ReplaceBullets;
    }

    private void OnDisable()
    {
        MapChanger.ChangeMap -= ReplaceBullets;
    }

    private void ReplaceBullets()
    {
        Instantiate(_parallelBullet, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
