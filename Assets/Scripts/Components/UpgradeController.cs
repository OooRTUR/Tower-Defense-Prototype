using System;
using UnityEngine;

class UpgradeController : MonoBehaviour, IViewComponent
{

    public ObjectArgEvent LevelUpdated;

    //init
    [SerializeField]
    private int initLevelValue = 1;
    [SerializeField]
    private int currentLevel = 1;
    [SerializeField]
    private int upgradeCostModfier = 10;

    private GoldStorage goldStorage;

    //props work
    public int CurrentLevel
    {
        private set
        {
            if (currentLevel != value)
            {
                currentLevel = value;
                CalculateUpgradeCost();
                LevelUpdated?.Invoke(currentLevel);
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
                ViewChanged?.Invoke(this, null);
            }
        }
    }

    private void CalculateUpgradeCost()
    {
        UpgradeCost = upgradeCostModfier * currentLevel;
    }


    //mono
    private void Awake()
    {
        LevelUpdated = new ObjectArgEvent();
        CurrentLevel = initLevelValue;
        CalculateUpgradeCost();
    }

    private void Start()
    {
        goldStorage = FindObjectOfType<GoldStorage>();
    }


    public void Upgrade()
    {
        if (goldStorage.GetResource(UpgradeCost) != 0)
            CurrentLevel++;
        else
            Debug.Log("Not enough gold");
    }


    // view implementation
    public event EventHandler ViewChanged;
    public object GetView()
    {
        return $"Upgrade Cost: {UpgradeCost}";
    }
}