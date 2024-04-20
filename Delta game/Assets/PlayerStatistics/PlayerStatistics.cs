using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public float health;
    public float maxHealth;
    
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }
    void Update()
    {
        slider.value = CalculateHealth();
        if (health <= 0)
        {
            Debug.Log("Death");
            SceneManager.LoadScene(1);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
