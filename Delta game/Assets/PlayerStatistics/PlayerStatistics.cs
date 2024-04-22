using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider slider;
    
    private float credits;
    public TMP_Text creditsLabel;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

        credits = 0;
        creditsLabel.text = credits.ToString();
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

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void CreditsIncrement()
    {
        credits += 1;
        creditsLabel.text = credits.ToString();
    }
}
