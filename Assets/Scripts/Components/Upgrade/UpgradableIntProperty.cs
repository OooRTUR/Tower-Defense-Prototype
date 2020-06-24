using UnityEngine;

public class UpgradableIntProperty : UpgradableProperty
{
    public UpgradableIntProperty(GameObject obj, object initValue, object perLevelModifier) : base(obj, initValue, perLevelModifier)
    {

    }

    protected override void LevelUpdated(object currentLevel)
    {
        Value = (int)initValue + (int)currentLevel * (int)PerLevelModifier;
    }
}