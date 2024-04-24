using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject _enemy;
    private bool isFinished;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (_enemy == null && !isFinished && !PlayerPrefs.HasKey("isFinishedCorr1"))
        {
            _enemy = Instantiate(enemyPrefab, new Vector3(0, 0.5f, -25), Quaternion.identity);
            isFinished = true;
            PlayerPrefs.SetInt("isFinishedCorr1", 1);
        }
    }
}
