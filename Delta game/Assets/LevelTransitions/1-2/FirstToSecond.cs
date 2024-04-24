using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstToSecond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerStatistics>().maxCredits >= 5)
        {
            Debug.Log(PlayerPrefs.GetInt("currentScene"));
            PlayerPrefs.SetInt("currentScene", PlayerPrefs.GetInt("currentScene") + 1);
            Debug.Log(PlayerPrefs.GetInt("currentScene"));
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene"));
        }
    }
}
