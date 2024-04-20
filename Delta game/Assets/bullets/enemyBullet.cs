using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 50.0f;
    private float _lifeTimeCounter = 0;
    private float lifeTime = 1f;
    private Rigidbody _rigidbody;
    private int _damageAmount = 20;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.velocity = transform.forward * speed;
    }

    void Update()
    {
        _lifeTimeCounter += Time.deltaTime;

        if (_lifeTimeCounter > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatistics>().TakeDamage(_damageAmount);
        }
    }
}