using System;
using UnityEngine;
public class BaseDamageTransmitter : MonoBehaviour
{
    //init 
    [SerializeField]
    public int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private BehaviourStrategyPick PickTargetChangedStrategy = BehaviourStrategyPick.DestroyObject;

    //RunTime
    public Transform Target { get; private set; }
    protected BehaviourStrategy TargetChangedStrategy;

    private void Awake()
    {
        Type type = Type.GetType(PickTargetChangedStrategy.ToString()); //target type
        TargetChangedStrategy = (BehaviourStrategy)Activator.CreateInstance(type); // an instance of target type

        this.enabled = false;
    }

    public virtual void Init(GameObject target, Vector3 startPosition)
    {
        Target = target.transform;
        transform.position = startPosition;

        this.enabled = true;
    }

    protected virtual void PerformMove()
    {

    }
    private void Update()
    {
        PerformMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Target.name)
        {
            var damageReceiver = other.GetComponent<DamageReceiver>();
            damageReceiver.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}