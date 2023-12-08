using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{   
    public TMP_Text text;
    public string value = 150.ToString();
    public string preText = "";
    public string postText = "";

    // Start is called before the first frame update
    void Start()
    {
        text.text = preText + value + postText;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static implicit operator TextMeshProUGUI(TextScript v)
    {
        throw new NotImplementedException();
    }
}
