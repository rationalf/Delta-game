using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject Camera;
    public float distance = 5;
    public GameObject currentWeapon = null;
    public bool canPickUp = false;
    public Animator anim;
    public Queue<GameObject> inventory = new Queue<GameObject>();
    public HashSet<String> setWeapons = new HashSet<string>();
    [SerializeField] private GameObject player;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
            {
                PickUp(hit.transform);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            Drop();
            currentWeapon = inventory.Dequeue();
            currentWeapon.SetActive(true);
            inventory.Enqueue(currentWeapon);
        }
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

    public void PickUp(Transform hit)
    {
        var lastLevelProgress = PlayerStatistics.lastLevelProgress;
            if (hit.tag == "Weapon")
            {
                if (canPickUp) Drop();
                currentWeapon = hit.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(140f, 0, -30f);
                canPickUp = true;
                
                if (!setWeapons.Contains("Weapon"))
                {
                    inventory.Enqueue(currentWeapon);
                    setWeapons.Add("Weapon");
                    PlayerPrefs.SetInt("Weapon", 1);
                    lastLevelProgress.Push("Weapon");
                }
            }
            if (hit.tag == "Weapon_Pistol")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(0.0262f, -0.0369f, 0.0316f);
                currentWeapon.transform.localEulerAngles = new Vector3(16.94f, 116.384f, 127.48f);
                canPickUp = true;
                if (!setWeapons.Contains("Weapon_Pistol"))
                {
                    inventory.Enqueue(currentWeapon);
                    setWeapons.Add("Weapon_Pistol");
                    PlayerPrefs.SetInt("Weapon_Pistol", 1);
                    lastLevelProgress.Push("Weapon_Pistol");
                }
            }
            if (hit.tag == "Weapon_Railgun")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = new Vector3(0.0982f, -0.104f, 0.0862f);
                currentWeapon.transform.localEulerAngles = new Vector3(20.008f, 114.659f, 122.522f);
                canPickUp = true;
                if (!setWeapons.Contains("Weapon_Railgun"))
                {
                    inventory.Enqueue(currentWeapon);
                    setWeapons.Add("Weapon_Railgun");
                    PlayerPrefs.SetInt("Weapon_Railgun", 1);
                    lastLevelProgress.Push("Weapon_Railgun");
                }
            }
    }

    void Drop()
    {
        canPickUp = false;
        currentWeapon.SetActive(false);
        currentWeapon = null;
    }
}