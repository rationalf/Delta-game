using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject Camera;
    public float distance = 3;
    public GameObject currentWeapon = null;
    public bool canPickUp = false;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon != null && currentWeapon.CompareTag("Weapon")) 
        {
            currentWeapon.GetComponent<Collider>().isTrigger = true;
            anim.SetBool("attack", true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && currentWeapon != null) 
        {
            anim.SetBool("attack", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && currentWeapon != null && currentWeapon.CompareTag("Weapon")) 
        {
            currentWeapon.GetComponent<Collider>().isTrigger = true;
            anim.SetBool("block", true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && currentWeapon != null) 
        {
            anim.SetBool("block", false);
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Weapon")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(140f, 0, -30f);
                canPickUp = true;
            }
            if (hit.transform.tag == "Weapon_Pistol")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(0.0262f, -0.0369f, 0.0316f);
                currentWeapon.transform.localEulerAngles = new Vector3(16.94f, 116.384f, 127.48f);
                canPickUp = true;
            }
        }


    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().isTrigger = false;
        currentWeapon.GetComponent<Rigidbody>().useGravity = true;
        canPickUp = false;
        currentWeapon = null;
    }
}