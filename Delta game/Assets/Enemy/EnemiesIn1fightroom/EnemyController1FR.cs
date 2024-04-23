using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1FR : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject[] _enemies;
    private int _len = 5;
    public bool isFinished;

    private void Start()
    {
        _enemies = new GameObject[_len];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_enemies[0] == null && !isFinished && !PlayerPrefs.HasKey("isFinished1FR"))
        {
            Debug.Log("Trigger");
            for (int i = 0; i < 5; i++)
            {
                _enemies[i] = Instantiate(enemyPrefab, new Vector3(10 + i * 3, 0.4f, -73), Quaternion.identity);
                _enemies[i].transform.Rotate(0, 180, 0);
            }
            isFinished = true;
            PlayerPrefs.SetInt("isFinished1FR", 1);
        }
    }
}