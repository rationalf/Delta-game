using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 3f;//shot delay
    public float laserDuration = 0.05f;
    public GameObject hand;
    LineRenderer laserLine;
    float fireTimer;
    private float damage;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("railgunDamage"))
        {
            PlayerPrefs.SetFloat("railgunDamage", 30);
            damage = PlayerPrefs.GetFloat("railgunDamage");
        }
        if (!PlayerPrefs.HasKey("railgunShotDelay"))
        {
            PlayerPrefs.SetFloat("railgunShotDelay", 3f);
            fireRate = PlayerPrefs.GetFloat("railgunShotDelay");
        }
    }

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
 
    void Update()
    {
        damage = PlayerPrefs.GetFloat("railgunDamage");
        fireRate = PlayerPrefs.GetFloat("railgunShotDelay");

        fireTimer += Time.deltaTime;
        if (hand.GetComponent<PickUpWeapon>().currentWeapon==null) return;
        if (Input.GetMouseButtonDown(0) && hand.GetComponent<PickUpWeapon>().currentWeapon.CompareTag("Weapon_Railgun") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange) && hit.transform.tag == "Enemy")
            {
                laserLine.SetPosition(1, hit.point);
                hit.transform.GetComponent<EnemyScript>().TakeDamage(damage);
            }
            else if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange) && hit.transform.tag == "BOSS")
            {
                laserLine.SetPosition(1, hit.point);
                hit.transform.GetComponent<BOSS>().TakeDamage(damage);
            }
            else  if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange) && hit.transform.tag == "Enemy2")
            {
                laserLine.SetPosition(1, hit.point);
                hit.transform.GetComponent<EnemyScript2>().TakeDamage(damage);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
