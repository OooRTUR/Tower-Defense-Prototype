using UnityEngine;
using System.Collections;

public class DamageTransmitter : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    public Transform Target { get; private set; }

    public void Init(Transform target, Vector3 startPosition)
    {
        Target = target;
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
            Destroy(gameObject);
            Debug.Log("Bullet destroyed");
        }
    }
}
