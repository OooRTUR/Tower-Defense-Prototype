using System;
using System.Collections.Generic;
using UnityEngine;
class UpgradeController : MonoBehaviour
{
    [SerializeField]
    private int currentLevel = 1;
    [SerializeField]
    private int upgradeCost = 10;

    public int CurrentLevel
    {
        private set
        {
            currentLevel = value;
            LevelUpdated?.Invoke(currentLevel);
        }
        get { return currentLevel; }
    }

    public ObjectArgEvent LevelUpdated;

    

    private void Awake()
    {
        LevelUpdated = new ObjectArgEvent();
    }
    //private void OnGUI()
    //{
    //    if (GUILayout.Button("Upgrade"))
    //    {
    //        CurrentLevel++;
    //    }
    //}
}

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

public class UpgradableIntProperty : UpgradableProperty
{
    public UpgradableIntProperty(GameObject obj, object initValue, object perLevelModifier) : base(obj,initValue,perLevelModifier)
    {
        
    }

    protected override void LevelUpdated(object currentLevel)
    {
        Value = (int)initValue + (int)currentLevel * (int)PerLevelModifier;       
    }
}

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