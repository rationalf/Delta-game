using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCanvas;
    private MouseLookX x;
    private MouseLookY y;
    
    public GameObject deathPanel;
    
    private float health;
    private bool isDead;
    void Start()
    {
        x = player.GetComponent<MouseLookX>();
        y = player.GetComponentInChildren<MouseLookY>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        health = player.GetComponent<PlayerStatistics>().health;
        if (health <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                Die();
            }
            
        }
    }
    
    void Die()
    {
        x = player.GetComponent<MouseLookX>();
        y = player.GetComponentInChildren<MouseLookY>();
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
        mainCanvas.SetActive(false);
        deathPanel.SetActive(true);
    }
    
    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    
    public void ExitDead()
    { 
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
