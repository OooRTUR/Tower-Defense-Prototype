using UnityEngine;
using System.Collections;

public class DamageTransmitter : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    public Transform Target { get; private set; }
    public string TargetTagName { get; private set; }

    public void Init(Transform target, string targetTagName, Vector3 startPosition)
    {
        Target = target;
        TargetTagName = targetTagName;
        transform.position = startPosition;

        this.enabled = true;
    }

    private void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, Target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            Target.position *= -1.0f;
        }
    }
}
