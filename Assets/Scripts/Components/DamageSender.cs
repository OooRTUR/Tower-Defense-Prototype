using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.UIElements;

class DamageSender : MonoBehaviour
{


    public float attackSpeed;

    public GameObject bulletPrefab;

    private void Update()
    {
        
    }

    public void PerformDamage()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        var newDamageTransmitter = newBullet.GetComponent<DamageTransmitter>();
        newDamageTransmitter.Init(currentTarget.transform, targetTagName, transform.position);
    }
}