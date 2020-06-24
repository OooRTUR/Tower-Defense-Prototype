using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthStorage : MonoBehaviour, IResourceStorage, IViewComponent
{
    //init 
    [SerializeField]
    private LevelConfiguration levelConfiguration = null;
    [SerializeField]
    public UnityEvent healthZeroEvent;


    private SensitiveIntValue playerHp;
    public int PlayerHp
    {
        get { return playerHp.Value; }
        private set
        {
            if(playerHp.Value!= value)
            {
                playerHp.Value = value;
                ViewChanged?.Invoke(this, null);
            }
        }
    }

    private void Awake()
    {
        healthZeroEvent = new UnityEvent();
        playerHp = new SensitiveIntValue(CompareMode.LessThan, levelConfiguration.playerStartHP, 0);        
        playerHp.Triggered.AddListener(delegate
        {
            healthZeroEvent?.Invoke();
        });
    }

    //IResourceStorage impl.
    public void AddResource(int value)
    {
        this.PlayerHp += value;
    }

    public int GetResource(int value)
    {
        this.PlayerHp -= value;
        return 0;
    }

    //IViewComponent impl.
    public event EventHandler ViewChanged;
    public object GetView()
    {
        return $"Health: {PlayerHp}";
    }
}