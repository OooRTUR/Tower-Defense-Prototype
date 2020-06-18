using PathCreation;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthInitValue = 25;
    public float damage = 10;
    public float gold = 25;

    [SerializeField]
    private SensitiveFloatValue Health;

    private void Awake()
    {
        Health = new SensitiveFloatValue(CompareMode.LessThan, healthInitValue, 0.0f);
        Health.Triggered.AddListener(OnHealthZero);
    }

    //private void Update()
    //{
    //    Health.Value -= 5.0f * Time.deltaTime;
    //}

    void OnHealthZero()
    {
        GameObject.Destroy(gameObject);
    }
}


