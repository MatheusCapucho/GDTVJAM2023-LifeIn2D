using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private float _xInput;
    private bool _isFacingLeft = true;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ShieldMechanic.TookDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        ShieldMechanic.TookDamage -= OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        _animator.SetTrigger("Damage");
    }

    void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        CheckFlip();
        if (Input.GetKeyDown(KeyCode.W))
            _animator.SetTrigger("Jump");
        _animator.SetFloat("XInput", Mathf.Abs(_xInput));
        _animator.SetFloat("YVelocity", _rb.velocity.y);
    }

    private void CheckFlip()
    {
        if (_isFacingLeft && _xInput > 0)
            Flip();
        else
        if (!_isFacingLeft && _xInput < 0)
            Flip();
    }

    private void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        var aux = transform.localScale;
        aux.x *= -1f;
        transform.localScale = aux;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.IsTouchingLayers())
        {
            _animator.SetTrigger("CancelFall");
        }
    }

}
