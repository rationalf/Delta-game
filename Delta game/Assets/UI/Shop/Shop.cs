using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Shop : MonoBehaviour
{ 
    public GameObject panel; 
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject crosshair;
    private MouseLookX x;
    private MouseLookY y;
    public static bool shopIsOpened;
    
    
    void Start()
    {
        x = player.GetComponent<MouseLookX>();
        y = player.GetComponentInChildren<MouseLookY>();
        CloseKatanaShop();
        ClosePistolShop();
        CloseRailgunShop();
        CloseShop();
    }
    

    public void OpenShop()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
        crosshair.SetActive(false);
        
        panel.SetActive(true);
        shopIsOpened = true;
    }
    public void CloseShop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1f;
        x.enabled = true;
        y.enabled = true;
        crosshair.SetActive(true);

        CloseKatanaShop();
        ClosePistolShop();
        CloseRailgunShop();
        panel.SetActive(false);
        shopIsOpened = false;
    }

    [SerializeField] private GameObject parameterShop;
    
    [SerializeField] private GameObject katanaShop;
    [SerializeField] private GameObject pistolShop;
    [SerializeField] private GameObject railgunShop;

    [SerializeField] private GameObject buypistol;
    [SerializeField] private GameObject buykatana;
    [SerializeField] private GameObject buyrailgun;
    public void OpenKatanaShop()
    {
        parameterShop.SetActive(false);
        pistolShop.SetActive(false);
        railgunShop.SetActive(false);
        CloseButtons();
        if (PlayerPrefs.HasKey("Weapon")) katanaShop.SetActive(true);
        else buykatana.SetActive(true);
    }
    public void CloseKatanaShop()
    {
        parameterShop.SetActive(true);
        katanaShop.SetActive(false);
        buykatana.SetActive(false);
    }
    

    public void OpenPistolShop()
    {
        parameterShop.SetActive(false);
        katanaShop.SetActive(false);
        railgunShop.SetActive(false);
        CloseButtons();
        if (PlayerPrefs.HasKey("Weapon_Pistol")) pistolShop.SetActive(true);
        else buypistol.SetActive(true);
    }
    
    public void ClosePistolShop()
    {
        parameterShop.SetActive(true);
        pistolShop.SetActive(false);
        buypistol.SetActive(false);
    }
    
    

    public void OpenRailgunShop()
    {
        parameterShop.SetActive(false);
        katanaShop.SetActive(false);
        pistolShop.SetActive(false);
        CloseButtons();
        if (PlayerPrefs.HasKey("Weapon_Railgun")) railgunShop.SetActive(true);
        else buyrailgun.SetActive(true);
    }
    
    public void CloseRailgunShop()
    {
        parameterShop.SetActive(true);
        railgunShop.SetActive(false);
        buyrailgun.SetActive(false);
    }

    public void CloseButtons()
    {
        buyrailgun.SetActive(false);
        buypistol.SetActive(false);
        buykatana.SetActive(false);
    }
}
