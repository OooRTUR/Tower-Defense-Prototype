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
    public override int ReceiveDamage(object value)
    {        
        return healthStorage.GetResource((int)value);
    }
}
