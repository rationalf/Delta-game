using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject newMenu;
    [SerializeField] private GameObject oldMenu;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("currentScene") != 0)
        {
            newMenu.SetActive(false);
            oldMenu.SetActive(true);
        }
        else
        {
            newMenu.SetActive(true);
            oldMenu.SetActive(false);
        }
    }

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("currentScene", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene"));
    }

    public void ExitGame()
    {
        PlayerPrefs.Save();
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
    
}
