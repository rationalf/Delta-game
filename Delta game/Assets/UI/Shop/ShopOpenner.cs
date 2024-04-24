using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenner : MonoBehaviour
{
    private bool _shopIsOpened;

    void Update()
    {
        _shopIsOpened = Shop.shopIsOpened;
        if (Input.GetKeyDown(KeyCode.F) && !_shopIsOpened)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 hitPosition = hitCollider.transform.position;
                hitPosition.y = transform.position.y;
                Vector3 direction = hitPosition - transform.position;
                if (Vector3.Dot(transform.forward, direction.normalized) > .5f)
                {
                    hitCollider.SendMessage("OpenShop", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && _shopIsOpened)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 hitPosition = hitCollider.transform.position;
                hitPosition.y = transform.position.y;
                Vector3 direction = hitPosition - transform.position;
                if (Vector3.Dot(transform.forward, direction.normalized) > .5f)
                {
                    hitCollider.SendMessage("CloseShop", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        
    }
}
