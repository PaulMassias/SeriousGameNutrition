using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static ButtonLamp;

public class SlideBar : MonoBehaviour
{

    public TMP_Text text;
    public Scrollbar scrollbar;
    public float valeur = 225;
    public float minValue = 225;
    public float maxValue = 325;
    public bool entier = false;


    float NormalizeBetweenMinMax(float value, float min, float max)
    {
        float minBar = min * 0.75f;
        float maxBar = max * 1.25f;

        // Normalisez la valeur entre 0 et 1
        float normalizedValue = (value - minBar) / (maxBar - minBar);

        // Étendez la plage normalisée de 0.1 à 1
        float scaledValue = normalizedValue * 0.9f + 0.1f;

        return scaledValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(entier)
        {
            text.text = valeur.ToString();
        }
        else
        {
            text.text = valeur + "g";

        }
        float size = NormalizeBetweenMinMax(valeur, minValue, maxValue);
        scrollbar.size = size;
        if (valeur >= minValue && valeur <= maxValue)
        {
            scrollbar.handleRect.GetComponent<Image>().color = Color.green;

        }else
        {
            scrollbar.handleRect.GetComponent<Image>().color = Color.red;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
