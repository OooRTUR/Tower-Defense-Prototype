using UnityEngine;
public class DestroyObject : BehaviourStrategy
{
    public override void Invoke(GameObject sender)
    {
        GameObject.Destroy(sender);
    }
}