using UnityEngine;

public class Highlightable : MonoBehaviour
{
    PickManager pickManager;

    [SerializeField] 
    private Color highlightColor = Color.white;
    [SerializeField] 
    private Renderer ownRenderer = null;

    private Color[] originalColors;
    private void Start()
    {
        pickManager = (PickManager)FindObjectOfType<PickManager>();

        if (ownRenderer == null) { ownRenderer = GetComponent<Renderer>(); }
        StoreOriginalColor();
    }
    private void StoreOriginalColor()
    {
        if (ownRenderer != null)
        {
            Material[] materials = ownRenderer.materials;
            originalColors = new Color[materials.Length];
            for (int i = 0; i < materials.Length; ++i) { originalColors[i] = materials[i].color; }
        }
    }
    private void OnMouseEnter()
    {
        if (ownRenderer != null)
        {
            Material[] materials = ownRenderer.materials;
            for (int i = 0; i < materials.Length; ++i) { materials[i].color = highlightColor; }
            ownRenderer.materials = materials;
        }
        pickManager.PickObject(ownRenderer.gameObject);
    }
    private void OnMouseExit()
    {
        if (ownRenderer != null)
        {
            Material[] materials = ownRenderer.materials;
            for (int i = 0; i < materials.Length; ++i) { materials[i].color = originalColors[i]; }
            ownRenderer.materials = materials;
        }
        pickManager.UnPickObject(ownRenderer.gameObject);
    }
}