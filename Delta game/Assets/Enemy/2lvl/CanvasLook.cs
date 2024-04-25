using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLook2 : MonoBehaviour
{
    public Transform camera;
    void LateUpdate()
    {
        transform.LookAt(camera);    
    }
}
