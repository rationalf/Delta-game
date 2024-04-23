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
    }
    public void CloseShop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1f;
        x.enabled = true;
        y.enabled = true;
        crosshair.SetActive(true);

        panel.SetActive(false);
    }

    [SerializeField] private GameObject parameterShop;
    [SerializeField] private GameObject katanaShop;
    public void OpenKatanaShop()
    {
        parameterShop.SetActive(false);
        pistolShop.SetActive(false);
        railgunShop.SetActive(false);
        katanaShop.SetActive(true);
    }

    public void CloseKatanaShop()
    {
        parameterShop.SetActive(true);
        katanaShop.SetActive(false);
    }
    
    [SerializeField] private GameObject pistolShop;
    public void OpenPistolShop()
    {
        parameterShop.SetActive(false);
        katanaShop.SetActive(false);
        railgunShop.SetActive(false);
        pistolShop.SetActive(true);
    }
    
    public void ClosePistolShop()
    {
        parameterShop.SetActive(true);
        pistolShop.SetActive(false);
    }
    
    [SerializeField] private GameObject railgunShop;
    public void OpenRailgunShop()
    {
        parameterShop.SetActive(false);
        katanaShop.SetActive(false);
        pistolShop.SetActive(false);
        railgunShop.SetActive(true);
    }
    
    public void CloseRailgunShop()
    {
        parameterShop.SetActive(true);
        railgunShop.SetActive(false);
    }
}
