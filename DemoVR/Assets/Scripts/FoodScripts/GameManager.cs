using System.Collections.Generic;
using UnityEngine;

public enum MealType
{
    Breakfast = 0,
    Lunch = 1,
    Dinner = 2,
}

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    private class Foods
    {
        public FoodData[] foodDataArray;
    }

    public static GameManager instance;
    [SerializeField]
    private TextAsset foodDataJson;
    [SerializeField]
    private EatingArea eatingArea;
    [SerializeField]
    private GUIManager guiManager;
    private Dictionary<string, FoodData> foodData;

    private MealType currentMealType;
    private Dictionary<MealType, List<FoodData>> foodsByMealType;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitValues();
            eatingArea.OnFruitEaten += AddFoodToCurrentMeal;
            LoadFoodData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Initializes the values of the GameManager, use for initialization and possible reset
    private void InitValues()
    {
        foodData = new();
        foodsByMealType = new();
        // Initialize the dictionary with an empty list for each meal type
        for (int i = 0; i < MealType.GetNames(typeof(MealType)).Length; i++)
        {
            foodsByMealType.Add((MealType)i, new());
        }
        currentMealType = MealType.Breakfast;
    }

    // Reads the provided JSON file and loads the food data
    private void LoadFoodData()
    {
        FoodData[] foodDataArray = JsonUtility.FromJson<Foods>(foodDataJson.text).foodDataArray;
        for (int i = 0; i < foodDataArray.Length; i++)
        {
            foodData.Add(foodDataArray[i].name, foodDataArray[i]);
        }
    }

    /// <summary>
    /// Adds the given food to the current meal
    /// </summary>
    /// <param name="foodData"> The food data of the food to add </param>
    public void AddFoodToCurrentMeal(FoodData foodData)
    {
        foodsByMealType[currentMealType].Add(foodData);
        UpdateGUI();
    }

    /// <summary>
    /// Returns the food data of the food with the given name
    /// </summary>
    /// <param name="foodName"> The name of the food </param>
    /// <returns></returns>
    public FoodData GetFoodDataByName(string foodName)
    {
        return foodData[foodName];
    }

    /// <summary>
    /// Sets the current meal to the next meal
    /// </summary>
    public void NextMeal()
    {
        currentMealType = (MealType)(((int)currentMealType + 1) % MealType.GetNames(typeof(MealType)).Length);
    }

    /// <summary>
    /// Returns the total data of the current meal
    /// </summary>
    /// <returns></returns>
    public FoodData GetCurrentMealTotalData()
    {
        return FoodData.TotalFromArray(foodsByMealType[currentMealType].ToArray());
    }

    /// <summary>
    /// Returns the total data of all meals
    /// </summary>
    /// <returns></returns>
    public FoodData GetTotalData()
    {
        FoodData[] mealsTotals = new FoodData[foodsByMealType.Count];
        for (int i = 0; i < mealsTotals.Length; i++)
        {
            mealsTotals[i] = FoodData.TotalFromArray(foodsByMealType[(MealType)i].ToArray());
        }
        return FoodData.TotalFromArray(mealsTotals);
    }

    // Called when the GUI needs to be updated (ie. when a food is added to a meal)
    private void UpdateGUI()
    {
        // TODO: Update GUI
        Debug.Log(GetCurrentMealTotalData());
        guiManager.UpdateSlideBar(GetCurrentMealTotalData());
    }
}