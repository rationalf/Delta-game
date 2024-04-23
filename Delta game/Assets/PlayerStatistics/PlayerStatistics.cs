using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private PickUpWeapon weapons;
    [SerializeField] private GameObject allWeaponsInGame;

    void Start()
    {
        Transform[] allWeapons = allWeaponsInGame.GetComponentsInChildren<Transform>();
        weapons = this.GameObject().GetComponentInChildren<PickUpWeapon>();
        
        //не забыть убрать !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetFloat("health");
            maxHealth = PlayerPrefs.GetFloat("maxHealth");
            credits = PlayerPrefs.GetFloat("credits");
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
            health = maxHealth;
            credits = 0;
            PlayerPrefs.SetFloat("health", maxHealth);
            PlayerPrefs.SetFloat("maxHealth", maxHealth);
            PlayerPrefs.SetFloat("credits", credits);
        }

        
        slider.value = CalculateHealth();
        creditsLabel.text = credits.ToString();
    }
    void Update()
    {
        slider.value = CalculateHealth();
        if (health <= 0)
        {
            Debug.Log("Death");
            Death();
        }

        if (health > maxHealth)
        {
            health = maxHealth;
            PlayerPrefs.SetFloat("health", health);
        }
    }

    public void TakeDamage(int damage)
    {
        if (Input.GetMouseButton(1) && weapons.currentWeapon.CompareTag("Weapon"))
        {
            health -= (float) damage / 10;
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
        credits += 1;
        PlayerPrefs.SetFloat("credits", credits);
        creditsLabel.text = credits.ToString();
    }

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject mainCanvas;
    private MouseLookX x;
    private MouseLookY y;
    void Death()
    {
        
        x = this.GetComponent<MouseLookX>();
        y = this.GetComponentInChildren<MouseLookY>();
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
        mainCanvas.SetActive(false);
        deathPanel.SetActive(true);
    }
}
