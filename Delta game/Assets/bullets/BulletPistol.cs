using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol: MonoBehaviour
{
    public float bulletLife = 3f;
    public float damageAmount;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("pistolDamage"))
        {
            PlayerPrefs.SetFloat("pistolDamage", 20);
            damageAmount = PlayerPrefs.GetFloat("pistolDamage");
        }
    }

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        damageAmount = PlayerPrefs.GetFloat("pistolDamage");
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
        else if (other.tag == "BOSS")
        {
            other.GetComponent<BOSS>().TakeDamage(damageAmount);
        }
    }
}
