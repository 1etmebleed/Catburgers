using TMPro;
using UnityEngine;

public class AutoScaleText : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private RectTransform rectTransform;

    public float maxFontSize = 100f; //Максимальный размер шрифта

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        AdjustFontSize();
    }

    void AdjustFontSize() //Автоматически скейлит шрифт
    {
        float height = rectTransform.rect.height;
        float width = rectTransform.rect.width;

        float maxFontSize = 100f; 

        float targetFontSize = Mathf.Min(maxFontSize, height / 10, width / 10);
        textMeshPro.fontSize = targetFontSize;
    }
}