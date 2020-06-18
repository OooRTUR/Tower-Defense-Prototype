using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.UIElements;

class DamageSender : MonoBehaviour
{
    [SerializeField]
    private float damage = 25.0f;

    List<DamageReceiver> damageReceivers;
    DamageReceiver currentTarget;
    [SerializeField]
    string targetTagName;
    

    private void Awake()
    {
        damageReceivers = new List<DamageReceiver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamageReceiver>() == null) return;
        if (!other.gameObject.CompareTag(targetTagName)) return;

        var newDamageReceiver = other.GetComponent<DamageReceiver>();
        damageReceivers.Add(newDamageReceiver);

        if(currentTarget == null)
            currentTarget = newDamageReceiver;
    }
    private void OnTriggerStay(Collider other)
    {
        if (currentTarget != null)
            PerformDamage();
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentTarget == other.GetComponent<DamageReceiver>())
            currentTarget = null;
        damageReceivers.Remove(other.GetComponent<DamageReceiver>());
    }

    public void PerformDamage()
    {
        currentTarget.ReceiveDamage(damage * Time.deltaTime);
    }
}