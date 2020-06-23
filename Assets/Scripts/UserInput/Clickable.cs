using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    private GameObject attachedGameObject;

    public UnityEvent Clicked;
    private void Awake()
    {
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                {
                    //userInput.SetInput(attachedGameObject);
                    Debug.Log("Clicked");
                    Clicked?.Invoke();
                }
            }
        }
    }
}
