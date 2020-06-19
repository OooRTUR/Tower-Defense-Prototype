using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour, IDamageReceivable
{
    public float healthInitValue = 25;
    [SerializeField]
    private SensitiveFloatValue Health;

    public DamageReceiver GetDamageReceiver()
    {
        return transform.GetComponent<DamageReceiver>();
    }

    private void Start()
    {
        Health = new SensitiveFloatValue(CompareMode.LessThan, healthInitValue, 0.0f);
        Health.Triggered.AddListener(delegate
        {
            Destroy(gameObject);
        });
        GetDamageReceiver().DamageReceivedEvent.AddListener(delegate (object value)
        {
            Health.Value -= (float)value;
        });
 
    }

}
