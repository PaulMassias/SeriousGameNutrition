using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, FoodData> foodDataDict;
    [SerializeField] TextAsset foodDataJson;

    void Start()
    {
        JsonUtility.FromJson<FoodData>(foodDataJson.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
