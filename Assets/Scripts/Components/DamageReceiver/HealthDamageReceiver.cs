using UnityEngine;
using System.Collections;
using System;

public class HealthDamageReceiver : DamageReceiver
{
    public BehaviourStrategyPick DeathStrategy;
    public int healthInitValue = 25;
    private SensitiveIntValue Health;

    private BehaviourStrategy healthZeroStrategy;

    private void Awake()
    {
        Health = new SensitiveIntValue(CompareMode.LessThan, healthInitValue, 0);
        Health.Triggered.AddListener(OnHealthZero);

        Type type = Type.GetType(DeathStrategy.ToString()); //target type
        healthZeroStrategy = (BehaviourStrategy)Activator.CreateInstance(type); // an instance of target type
    }

    private void OnHealthZero()
    {
        healthZeroStrategy.Invoke(gameObject);
    }

    public override int ReceiveDamage(object value)
    {
        return Health.Value -= (int)value;
        //Debug.Log(Health.Value);
    }
}




