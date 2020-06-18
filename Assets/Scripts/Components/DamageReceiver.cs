using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour
{
    public float healthInitValue = 25;
    [SerializeField]
    private SensitiveFloatValue Health;

    

    private void Awake()
    {
        UnityEvent configuredEvent = null;
        if (Health != null)
            configuredEvent = Health.Triggered;
        Health = new SensitiveFloatValue(CompareMode.LessThan, healthInitValue, 0.0f);
        Health.Triggered = configuredEvent;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void StopGame()
    {
        Debug.Log("GAME OVER!");
    }

    public void ReceiveDamage(float value)
    {
        Health.Value -= value;
    }

}
