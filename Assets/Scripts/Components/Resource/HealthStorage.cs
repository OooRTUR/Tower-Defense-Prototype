using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class HealthStorage : MonoBehaviour, IResourceStorage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private SensitiveIntValue playerHp;
    public int PlayerHp
    {
        get { return playerHp.Value; }
        private set
        {
            if(playerHp.Value!= value)
            {
                playerHp.Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlayerHp"));
            }
        }
    }
    [SerializeField]
    private LevelConfiguration levelConfiguration;
    public UnityEvent healthZeroEvent;



    private void Awake()
    {
        healthZeroEvent = new UnityEvent();
        playerHp = new SensitiveIntValue(CompareMode.LessThan, levelConfiguration.playerStartHP, 0);        
        playerHp.Triggered.AddListener(delegate
        {
            healthZeroEvent?.Invoke();
        });
    }

    public void AddResource(int value)
    {
        this.PlayerHp += value;
    }

    public int GetResource(int value)
    {
        this.PlayerHp -= value;
        return 0;
    }

}