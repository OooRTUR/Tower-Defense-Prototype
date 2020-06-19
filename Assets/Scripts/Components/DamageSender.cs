using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.UIElements;

class DamageSender : MonoBehaviour
{

    [SerializeField]
    private float RPM = 10;

    private float nextShoot;
    private float fireDelay;

    public GameObject bulletPrefab;

    private Transform target;


    private void Awake()
    {
        fireDelay = 60.0f / RPM;

    }

    private void Start()
    {
        transform.GetComponent<TargetSearch>().TargetFound.AddListener(delegate (object target)
        {
            this.target = (Transform)target;
        });
    }

    private void Update()
    {
        if(target!=null)
            PerformDamage();
    }


    public void PerformDamage()
    {
        if (nextShoot > Time.time) return;

        Debug.Log($"new shoot: Time: {Time.time} : NextShoot: {nextShoot}");

        GameObject newBullet = Instantiate(bulletPrefab);
        var newDamageTransmitter = newBullet.GetComponent<DamageTransmitter>();
        newDamageTransmitter.Init((Transform)target, transform.position);

        ResetAttackTimer();
    }

    private void ResetAttackTimer()
    {
        nextShoot = Time.time + fireDelay;
    }
}