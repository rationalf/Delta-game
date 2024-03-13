using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3f;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
}
