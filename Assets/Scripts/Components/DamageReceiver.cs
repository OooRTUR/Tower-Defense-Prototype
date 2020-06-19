using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour
{
    public ObjectArgEvent DamageReceivedEvent;

    private void Awake()
    {
        DamageReceivedEvent = new ObjectArgEvent();
    }

    public void ReceiveDamage(object value)
    {
        DamageReceivedEvent?.Invoke(value);
    }

}

public interface IDamageReceivable
{
    DamageReceiver GetDamageReceiver();

}
