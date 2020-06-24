using UnityEngine;
using System.Collections;
using System.ComponentModel;
using UnityEngine.UI;
using System;

public class BaseViewController : MonoBehaviour
{
    [SerializeField]
    private GameObject ViewObject;
    [SerializeField]
    private Text attachedView;

    private IViewComponent viewComponent;

    private void Awake()
    {
        viewComponent = ViewObject.GetComponent<IViewComponent>();
        viewComponent.ViewChanged += UpdateView;
    }

    private void Start()
    {
        UpdateView(ViewObject, null);
    }

    private void UpdateView(object sender, EventArgs e)
    {
        attachedView.text = (string)viewComponent.GetView();
    }
}

public interface IViewComponent
{
    event EventHandler ViewChanged;
    object GetView();

}
