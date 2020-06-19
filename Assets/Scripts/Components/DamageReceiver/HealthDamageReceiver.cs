using UnityEngine;
using System.Collections;
using System;

public class HealthDamageReceiver : DamageReceiver
{
    public string strategyName;
    public float healthInitValue = 25;
    private SensitiveFloatValue Health;

    private BehaviourStrategy healthZeroStrategy;

    private void Awake()
    {
        Health = new SensitiveFloatValue(CompareMode.LessThan, healthInitValue, 0.0f);
        Health.Triggered.AddListener(OnHealthZero);

        Type type = Type.GetType(strategyName); //target type
        healthZeroStrategy = (BehaviourStrategy)Activator.CreateInstance(type); // an instance of target type
    }

    private void OnHealthZero()
    {
        healthZeroStrategy.Invoke(gameObject);
    }

    public override void ReceiveDamage(object value)
    {
        Health.Value -= (float)value;
        Debug.Log(Health.Value);
    }
}




