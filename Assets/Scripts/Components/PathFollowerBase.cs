using UnityEngine;
using System.Collections;
using Unity.Entities.UniversalDelegates;

public class PathFollowerBase : MonoBehaviour
{
    [SerializeField]
    protected float speed = 2.0f;


    private void Update()
    {
        PerformMove();
    }

    public virtual void Init(GameObject pathContainer)
    {

    }

    protected virtual void PerformMove()
    {
    }
}
