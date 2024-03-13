using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLook : MonoBehaviour
{
    public Transform camera;
    void LateUpdate()
    {
        transform.LookAt(camera);    
    }
}
