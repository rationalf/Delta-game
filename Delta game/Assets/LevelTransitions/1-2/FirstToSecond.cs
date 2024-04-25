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
            PlayerPrefs.SetInt("currentScene", PlayerPrefs.GetInt("currentScene") + 1);
            SceneManager.LoadScene(2);
        }
    }
}
