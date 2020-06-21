using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SingleDamageReceiver : DamageReceiver
{
    
    HealthStorage healthStorage;
    private void Start()
    {
        healthStorage = (HealthStorage)FindObjectOfType<HealthStorage>();
        
    }
    public override void ReceiveDamage(object value)
    {        
        healthStorage.GetResource((int)value);
    }
}
