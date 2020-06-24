using UnityEngine;

class SensitiveComponent : MonoBehaviour
{
    ISensitiveValueContainer sensitiveValueContainer;

    private void Awake()
    {
        sensitiveValueContainer = transform.GetComponent<ISensitiveValueContainer>();
    }

    private void Update()
    {
        sensitiveValueContainer.CalculateSensitiveValues();
    }
}