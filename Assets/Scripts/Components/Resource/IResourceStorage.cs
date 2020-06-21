using System;
using UnityEngine;
using UnityEngine.Events;

public interface IResourceStorage
{
    void AddResource(int value);
    int GetResource(int value);
}



