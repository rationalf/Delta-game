using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSecret : MonoBehaviour
{
    [SerializeField] Vector3 dPos;
    [SerializeField] private GameObject doorLeft;
    [SerializeField] private GameObject doorRight;
    private float _speed = 0.01f;
    private Vector3 _startLeft;
    private Vector3 _startRight;
    private bool open;
    private bool _operate;
    private bool _isPlaced = true;
    
    private void Start()
    {
        _startLeft = doorLeft.transform.position;
        _startRight = doorRight.transform.position;
    }

    private void Update()
    {
        if (!_operate) return;
        if (open)
        {
            _isPlaced = Vector3.Distance(_startLeft + dPos, doorLeft.transform.position) <= 0.01f;
            if (!_isPlaced)
            {
                Vector3 posLeft = doorLeft.transform.position + dPos * _speed; 
                Vector3 posRight = doorRight.transform.position - dPos * _speed;
                doorLeft.transform.position = posLeft;
                doorRight.transform.position = posRight;  
            }
        }
        else 
        {
            _isPlaced = Vector3.Distance(_startLeft - dPos, doorLeft.transform.position) <= 0.01f;
            if (!_isPlaced)
            { 
                Vector3 posLeft = doorLeft.transform.position - dPos * _speed; 
                Vector3 posRight = doorRight.transform.position + dPos * _speed;
                doorLeft.transform.position = posLeft;
                doorRight.transform.position = posRight;    
            }
        }
    }
    
    
    [SerializeField] GameObject room;
    private EnemyController1FR _isFinished;

    public void Operate()
    {
        _isFinished = room.GetComponent<EnemyController1FR>();
        if (!_isPlaced || !_isFinished.isFinished) return;
        _startLeft = doorLeft.transform.position;
        _startRight = doorRight.transform.position;
        open = !open;
        _operate = true;
    }
}