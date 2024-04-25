using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public Slider slider;
    
    public float credits;
    public float maxCredits;
    public TMP_Text creditsLabel;
    private PickUpWeapon weapons;
    [SerializeField] private GameObject allWeaponsInGame;

    private float _damageResistance;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //не забыть убрать !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
             
        Transform[] allWeapons = allWeaponsInGame.GetComponentsInChildren<Transform>();
        weapons = this.GameObject().GetComponentInChildren<PickUpWeapon>();
        
        
        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetFloat("health");
            maxHealth = PlayerPrefs.GetFloat("maxHealth");
            credits = PlayerPrefs.GetFloat("credits");
            _damageResistance = PlayerPrefs.GetFloat("damageResistance");
            
            for (int i = 0; i < allWeapons.Length; i++)
            {
                if (PlayerPrefs.HasKey(allWeapons[i].tag))
                {
                    weapons.PickUp(allWeapons[i]);
                    
                }
            }
        }
        else
        {
            maxHealth = 100;
            health = maxHealth;
            credits = 0;
            PlayerPrefs.SetFloat("health", maxHealth);
            PlayerPrefs.SetFloat("maxHealth", maxHealth);
            PlayerPrefs.SetFloat("credits", credits);
            PlayerPrefs.SetFloat("_damageResistance", 50);
            PlayerPrefs.SetFloat("income", 1);
        }
        
        slider.value = CalculateHealth();
        creditsLabel.text = credits.ToString();
        
    }
    void Update()
    {
        slider.value = CalculateHealth();
        if (health > maxHealth) health = maxHealth;
        health = PlayerPrefs.GetFloat("health", health);
        
        credits = PlayerPrefs.GetFloat("credits");
        creditsLabel.text = credits.ToString();
    }
    
    public void TakeDamage(float damage)
    {
        if (Input.GetMouseButton(1) && weapons.currentWeapon.CompareTag("Weapon"))
        {
            _damageResistance = PlayerPrefs.GetFloat("damageResistance");
            health = health - damage + _damageResistance;
        }
        else
        {
            health -= damage;
        }
        PlayerPrefs.SetFloat("health", health);

    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void CreditsIncrement()
    {
        credits += PlayerPrefs.GetFloat("income");
        maxCredits = Math.Max(credits, maxCredits);
        PlayerPrefs.SetFloat("credits", credits);
        creditsLabel.text = credits.ToString();
    }
}
