using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PickUpWeapon>().canPickUp == false)
        {
            if(Input.GetButtonDown("Fire1")) _animator.SetBool("attack", true);
            else if (Input.GetButtonUp("Fire1")) _animator.SetBool("attack", false);
        }
        
    }
}
