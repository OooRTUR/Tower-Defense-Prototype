using UnityEngine;
using System.Collections;
using System;

public class ChaseDamageTransmitter : BaseDamageTransmitter
{


    protected override void PerformMove()
    {
        if (Target != null)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        }
        else
        {
            TargetChangedStrategy.Invoke(gameObject);
        }
    }


}
