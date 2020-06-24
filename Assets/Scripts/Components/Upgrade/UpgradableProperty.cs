using UnityEngine;

public class UpgradableProperty
{
    UpgradeController upgradeController;
    protected object value;
    public object Value
    {
        get { return value; }
        protected set { this.value = value; }
    }

    protected object initValue;

    protected object PerLevelModifier;

    public UpgradableProperty(GameObject obj, object initValue, object perLevelModifier)
    {
        this.initValue = initValue;
        Value = initValue;
        this.PerLevelModifier = perLevelModifier;
        upgradeController = obj.GetComponent<UpgradeController>();
        if (upgradeController != null)
        {
            upgradeController.LevelUpdated.AddListener(LevelUpdated);
        }
        LevelUpdated(upgradeController.CurrentLevel);
        //Debug.Log(Value);
        //Debug.Log(Value.GetType());
    }

    protected virtual void LevelUpdated(object currentLevel)
    {

    }
}
