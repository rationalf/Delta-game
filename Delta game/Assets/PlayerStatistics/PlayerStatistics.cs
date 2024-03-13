using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Death");
            SceneManager.LoadScene("MainScene");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
