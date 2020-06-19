using UnityEngine;
using System.Collections;

public class DamageTransmitter : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    public Transform Target { get; private set; }

    public void Init(GameObject target, Vector3 startPosition)
    {
        Target = target.transform;
        transform.position = startPosition;

        this.enabled = true;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == Target.name)
        {
            var damageReceiver = other.GetComponent<DamageReceiver>();
            damageReceiver.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
