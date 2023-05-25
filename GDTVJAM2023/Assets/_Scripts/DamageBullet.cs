using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExtensions;

public class DamageBullet : Bullet
{
    [SerializeField] private LayerMask _environmentMask;
    [SerializeField] private LayerMask _playerMask;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_environmentMask.Contains(collision.gameObject.layer))
        {
            Destroy(this.gameObject);
        }

        if (_playerMask.Contains(collision.gameObject.layer) && !collision.gameObject.GetComponent<Invulnerability>().IsInvulnerable())
        {
            ShieldMechanic.TookDamage?.Invoke();
            Destroy(this.gameObject);
        } 
        
        else
        {
            Destroy(this.gameObject);

        }

    }

}
