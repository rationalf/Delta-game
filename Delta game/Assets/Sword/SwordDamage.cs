using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private float damageAmount = 50;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("katanaDamage"))
            PlayerPrefs.SetFloat("katanaDamage", 50);
    }

    private void Update()
    {
        damageAmount = PlayerPrefs.GetFloat("katanaDamage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
        if (other.tag == "Enemy2")
        {
            other.GetComponent<EnemyScript2>().TakeDamage(damageAmount);
        }
        if (other.tag == "BOSS")
        {
            other.GetComponent<BOSS>().TakeDamage(damageAmount);
        }
    }
}
