using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideBar : MonoBehaviour
{

    public TMP_Text text;
    public Scrollbar scrollbar;
    public float minValue = 225;
    public float maxValue = 325;
    public bool isInt = false;


    float NormalizeBetweenMinMax(float value, float min, float max)
    {
        float minBar = min * 0.75f;
        float maxBar = max * 1.25f;

        // Normalisez la valeur entre 0 et 1
        float normalizedValue = (value - minBar) / (maxBar - minBar);

        // �tendez la plage normalis�e de 0.1 � 1
        float scaledValue = normalizedValue * 0.9f + 0.1f;

        return scaledValue;
    }

    public void SetValue(float value)
    {
        if (isInt)
        {
            text.text = value.ToString();
        }
        else
        {
            text.text = value + " g";

        }
        float size = NormalizeBetweenMinMax(value, minValue, maxValue);
        scrollbar.size = size;
        if (value >= minValue && value <= maxValue)
        {
            scrollbar.handleRect.GetComponent<Image>().color = Color.green;

        }
        else
        {
            scrollbar.handleRect.GetComponent<Image>().color = Color.red;

        }
    }
}
