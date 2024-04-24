using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController1_1FR : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject[] _enemies;
    private int _len = 5;
    public bool isFinished;
    public bool passed;
    [SerializeField] private GameObject player;

    private void Start()
    {
        _enemies = new GameObject[_len];
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (_enemies[0] == null && !isFinished && !PlayerPrefs.HasKey("isFinished1_1FR"))
        {
            for (int i = 0; i < 5; i++)
            {
                _enemies[i] = Instantiate(enemyPrefab, new Vector3(60, 0.4f, -15 + i * 3), Quaternion.identity);
                _enemies[i].transform.Rotate(0, -90, 0);
            }
            isFinished = true;
            PlayerPrefs.SetInt("isFinished1_1FR", 1);
        }
    }
}