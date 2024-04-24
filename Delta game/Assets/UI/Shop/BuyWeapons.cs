using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuyWeapons : MonoBehaviour
{

    [SerializeField] private GameObject allWeapons;
    [SerializeField] private GameObject player;
    
    private Transform[] weapons;
    private PickUpWeapon _pickUpWeapon;
    // Start is called before the first frame update
    void Start()
    {
        weapons = allWeapons.GetComponentsInChildren<Transform>();
        _pickUpWeapon = player.GameObject().GetComponentInChildren<PickUpWeapon>();
    }
    
    public void BuyKatana()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].CompareTag("Weapon") && PlayerPrefs.GetFloat("credits") >= 10)
            {
                _pickUpWeapon.PickUp(weapons[i]);
                PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-10);
            }
        }
        this.GameObject().GetComponentInChildren<Shop>().OpenKatanaShop();
    }
    public void BuyPistol()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].CompareTag("Weapon_Pistol") && PlayerPrefs.GetFloat("credits") >= 10)
            {
                _pickUpWeapon.PickUp(weapons[i]);
                PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-10);
            }
        }
        this.GameObject().GetComponentInChildren<Shop>().OpenPistolShop();

    }
    public void BuyRailgun()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].CompareTag("Weapon_Railgun") && PlayerPrefs.GetFloat("credits") >= 10)
            {
                _pickUpWeapon.PickUp(weapons[i]);
                PlayerPrefs.SetFloat("credits", PlayerPrefs.GetFloat("credits")-10);
            }
        }
        this.GameObject().GetComponentInChildren<Shop>().OpenRailgunShop();
    }
}
