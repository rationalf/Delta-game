using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] Vector3 dPos;
    [SerializeField] private GameObject doorLeft;
    [SerializeField] private GameObject doorRight;
    public float _speed;
    private Vector3 _startLeft;
    private Vector3 _startRight;
    private bool open;
    private bool _operate;
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
            bool isPlaced = Vector3.Distance(_startLeft + dPos, doorLeft.transform.position) <= 0.01f;
            if (!isPlaced)
            {
                Vector3 posLeft = doorLeft.transform.position + dPos * _speed; 
                Vector3 posRight = doorRight.transform.position - dPos * _speed;
                doorLeft.transform.position = posLeft;
                doorRight.transform.position = posRight;  
            }
        }
        else 
        {
            bool isPlaced = Vector3.Distance(_startLeft - dPos, doorLeft.transform.position) <= 0.01f;
            if (!isPlaced)
            { 
                Vector3 posLeft = doorLeft.transform.position - dPos * _speed; 
                Vector3 posRight = doorRight.transform.position + dPos * _speed;
                doorLeft.transform.position = posLeft;
                doorRight.transform.position = posRight;    
            }
        }
    }

    public void Operate()
    {
        _startLeft = doorLeft.transform.position;
        _startRight = doorRight.transform.position;
        open = !open;
        _operate = true;
    }
}