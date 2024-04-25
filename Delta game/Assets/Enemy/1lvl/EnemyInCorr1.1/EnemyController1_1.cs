using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController1_1 : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;
    private bool isFinished;
    [SerializeField] private GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_enemy == null && !isFinished && !PlayerPrefs.HasKey("isFinishedCorr1.1"))
        {
            _enemy = Instantiate(enemyPrefab, new Vector3(16.5f, 0.5f, -41), Quaternion.identity);
            isFinished = true;
            PlayerPrefs.SetInt("isFinishedCorr1.1", 1);
        }
    }
}
