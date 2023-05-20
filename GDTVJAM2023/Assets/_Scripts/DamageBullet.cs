using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExtensions;

public class DamageBullet : Bullet
{
    [SerializeField] private LayerMask _environmentMask;
    [SerializeField] private LayerMask _playerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_environmentMask.Contains(collision.gameObject.layer))
        {
            Destroy(this.gameObject);
        }

        if (_playerMask.Contains(collision.gameObject.layer))
        {
            Destroy(this.gameObject);
        }

       
    }

}
