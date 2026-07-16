using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class BarFill : MonoBehaviour
{
    [SerializeField] private float MaxWidth = 100f;
    [SerializeField] private float MaxHeight = 100f;
    [SerializeField] private float Percentage = 1f;
    [SerializeField] private bool Horizontal = true;

    private RectTransform rectTransform;

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        ApplySize();
    }

    #if UNITY_EDITOR
    private void Update()
    {
        if (!Application.isPlaying)
            ApplySize();
    }
    #endif

    private void OnValidate()
    {
        rectTransform = GetComponent<RectTransform>();
        ApplySize();
    }

    private void ApplySize()
    {
        if (rectTransform == null)
            return;

        if (Horizontal)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, MaxWidth * Percentage);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, MaxHeight);
        }
        else
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, MaxWidth);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, MaxHeight * Percentage);
        }
    }
}