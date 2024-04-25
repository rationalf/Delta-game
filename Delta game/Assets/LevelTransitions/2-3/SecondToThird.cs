using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondToThird: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("currentScene", PlayerPrefs.GetInt("currentScene") + 1);
            SceneManager.LoadScene(3);
        }
    }
}
