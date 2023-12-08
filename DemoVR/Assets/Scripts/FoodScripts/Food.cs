using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private string foodName;
    public FoodData foodData;

    private void Start()
    {
        try
        {
            foodData = GameManager.instance.GetFoodDataByName(foodName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error while getting food data: " + e.Message + ". There is probably no corresponding food data for the aliment " + foodName + " in the JSON file.");
        }
    }
}
