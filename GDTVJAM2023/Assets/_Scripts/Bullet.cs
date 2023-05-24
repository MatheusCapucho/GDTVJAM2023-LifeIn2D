using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    [SerializeField]
    protected float _speed = 5f;
    [SerializeField]
    protected float _maxSpeed = 10f;
    protected float _currentSpeed;
    [SerializeField]
    private float _lifetime = 10f;

    [SerializeField]
    protected GameObject _parallelBullet;
    protected GameObject _currentBullet;

    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentBullet = this.gameObject;
        _currentSpeed = _speed;

    }
    private void Start()
    {   
        _rb.AddForce(transform.up * _speed, ForceMode2D.Force);
        Destroy(this.gameObject, _lifetime);
    }

}
