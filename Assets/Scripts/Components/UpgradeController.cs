using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
class UpgradeController : MonoBehaviour, INotifyPropertyChanged, GetPickabletype
{

    [SerializeField]
    private int initLevelValue = 1;
    [SerializeField]
    private int currentLevel = 1;
    [SerializeField]
    private int upgradeCostModfier = 10;

    public int CurrentLevel
    {
        private set
        {
            if (currentLevel != value)
            {
                currentLevel = value;
                LevelUpdated?.Invoke(currentLevel);
                UpgradeCost = upgradeCostModfier * value;
            }
        }
        get { return currentLevel; }
    }

    private int upgradeCost;
    public int UpgradeCost
    {
        get { return upgradeCost; }
        private set
        {
            if (upgradeCost != value)
            {
                upgradeCost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpgradeCost"));                
            }
        }
    }

    public ObjectArgEvent LevelUpdated;

    public event PropertyChangedEventHandler PropertyChanged;

    private void Awake()
    {
        LevelUpdated = new ObjectArgEvent();
        CurrentLevel = initLevelValue;
    }

    public Type GetPickableType()
    {
        return this.GetType();
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