using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _lifetime = 10f;

    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.AddForce(transform.up * _speed, ForceMode2D.Force);
        Destroy(this.gameObject, _lifetime);
    }

}
