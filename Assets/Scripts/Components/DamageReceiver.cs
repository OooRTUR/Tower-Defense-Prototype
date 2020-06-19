using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    DamageReceiveStrategy damageReceiveStrategy;

    private void Awake()
    {
    }
    public void ReceiveDamage(object value)
    {
        damageReceiveStrategy.ReceiveDamage(value);
    }

}

public class DamageReceiveStrategy : MonoBehaviour
{

    public float healthInitValue = 25;
    public SensitiveFloatValue Health { private set; get; }

    private void Awake()
    {
        Health = new SensitiveFloatValue(CompareMode.LessThan, healthInitValue, 0.0f);
    }
    public void ReceiveDamage(object value)
    {

    }
}

public interface IDamageReceivable
{
    DamageReceiver GetDamageReceiver();

}
