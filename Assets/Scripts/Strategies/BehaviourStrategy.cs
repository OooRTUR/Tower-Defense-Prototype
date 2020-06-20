using UnityEngine;

public enum BehaviourStrategyPick {None, DestroyObject}

public abstract class BehaviourStrategy
{
    public abstract void Invoke(GameObject sender);
}
