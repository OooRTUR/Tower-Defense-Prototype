using UnityEngine;

public class PathFollowerBase : MonoBehaviour
{
    //init
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
