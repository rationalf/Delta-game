using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject crosshair;
    private MouseLookX x;
    private MouseLookY y;
    
    public GameObject panel;
    private bool openedShop;
    private bool openedPause;
    
    void Start()
    {
        x = player.GetComponent<MouseLookX>();
        y = player.GetComponentInChildren<MouseLookY>();
        ClosePause();
        
    }

    private void Update()
    {
        openedShop = Shop.shopIsOpened;
        if (!openedPause && !openedShop && Input.GetKey(KeyCode.Escape))
        {
            OpenPause();
            openedPause = true;
        }
        else if (openedPause && !openedShop && Input.GetKey(KeyCode.Escape))
        {
            ClosePause();
            openedPause = false;
        }
    }

    public void OpenPause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
        crosshair.SetActive(false);
        
        panel.SetActive(true);
    }
    
    public void ClosePause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1f;
        x.enabled = true;
        y.enabled = true;
        crosshair.SetActive(true);

        panel.SetActive(false);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene"));
    }
    
    public void ExitAlive()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.Save();
    }
}
