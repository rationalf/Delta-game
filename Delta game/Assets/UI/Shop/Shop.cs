using System.Collections;
using System.Collections.Generic;
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
}
