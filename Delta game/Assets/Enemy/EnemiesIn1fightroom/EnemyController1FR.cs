using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1FR : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject[] _enemies;
    private int _len = 5;

    private void Start()
    {
        _enemies = new GameObject[_len];
        //if player is close
        for (int i = 0; i < 5; i++)
        {
            _enemies[i] = Instantiate(enemyPrefab);
            _enemies[i].transform.position = new Vector3(10+i*3, 0.4f, -73);
            _enemies[i].transform.Rotate(0,180,0);
        }
    }

    void Update()
    {
        
    }
}