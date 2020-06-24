using UnityEngine;

public class UpgradableFloatProperty : UpgradableProperty
{
    public UpgradableFloatProperty(GameObject obj, object initValue, object perLevelModifier) : base(obj, initValue, perLevelModifier)
    {

    }

    protected override void LevelUpdated(object currentLevel)
    {
        Value = (float)initValue + (int)currentLevel * (float)PerLevelModifier;
    }
}