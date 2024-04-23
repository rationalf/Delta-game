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
    public static Stack<string> lastLevelProgress;
    private bool isDead;

    void Start()
    {
        Transform[] allWeapons = allWeaponsInGame.GetComponentsInChildren<Transform>();
        weapons = this.GameObject().GetComponentInChildren<PickUpWeapon>();
        lastLevelProgress = new Stack<string>();
        
        //не забыть убрать !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //PlayerPrefs.DeleteAll();
        
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
            lastLevelProgress.Push("health");
            PlayerPrefs.SetFloat("maxHealth", maxHealth);
            lastLevelProgress.Push("maxHealth");
            PlayerPrefs.SetFloat("credits", credits);
            lastLevelProgress.Push("credits");
        }
        
        slider.value = CalculateHealth();
        creditsLabel.text = credits.ToString();
        
    }
    void Update()
    {
        slider.value = CalculateHealth();
        if (health <= 0)
        {
            if (!isDead)
            {
                Death();
            }
            isDead = true;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
            PlayerPrefs.SetFloat("health", health);
            lastLevelProgress.Push("health");
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
        lastLevelProgress.Push("health");
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void CreditsIncrement()
    {
        credits += 1;
        PlayerPrefs.SetFloat("credits", credits);
        lastLevelProgress.Push("credits");
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
        ExitDead();
    }

    public void Restart()
    {
        for (int i = 0; i < lastLevelProgress.Count; i++)
        {
            PlayerPrefs.DeleteKey(lastLevelProgress.Peek());
            lastLevelProgress.Pop();
        }
        //Загружаем сцену по индексу сохраненному в памяти
        SceneManager.LoadScene(1);
    }

    public void ExitDead()
    {
        for (int i = 0; i < lastLevelProgress.Count; i++)
        {
            PlayerPrefs.DeleteKey(lastLevelProgress.Peek());
            lastLevelProgress.Pop();
        }
        //Загружаем сцену меню
    }

    public void ExitAlive()
    {
        //загружаем сцену меню
    }
    public void Pause()
    {
        
    }
}
