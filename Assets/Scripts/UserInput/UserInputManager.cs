using UnityEngine;
using System.Collections;

public class UserInputManager : MonoBehaviour
{
    private GameObject _lastPick;
    public GameObject LastPick
    {

        private set
        {
            if (_lastPick != value)
            {
                _lastPick = value;
            }
        }
        get
        {
            return _lastPick;
        }
    }

    public void SetInput(GameObject attachedGameObject)
    {
        LastPick = attachedGameObject;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
