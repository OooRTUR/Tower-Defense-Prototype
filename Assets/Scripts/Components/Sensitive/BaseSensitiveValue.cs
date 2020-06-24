using UnityEngine.Events;

public enum CompareMode { Less, LessThan, Equal, MoreThan, More }
public abstract class BaseSensitiveValue
{
    public UnityEvent Triggered;
    public abstract bool CheckForTrigger();
}