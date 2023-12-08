using System.Collections.Generic;

[System.Serializable]
public class FoodData
{
    public string name;
    public float carbohydrates;
    public float lipids;
    public float proteins;
    public float fibers;
    public float water;
    public float alcohol;
    public int ultraProcessedProducts;

    public enum FoodDataProperty
    {
        Carbohydrates,
        Lipids,
        Proteins,
        Fibers,
        Water,
        Alcohol,
        UltraProcessedProducts
    }

    private static Dictionary<FoodDataProperty, float> propertyRecommendedMinValues = new()
    {
        { FoodDataProperty.Carbohydrates, 0.5f },
        { FoodDataProperty.Lipids, 0.2f },
        { FoodDataProperty.Proteins, 0.1f },
        { FoodDataProperty.Fibers, 0.3f },
        { FoodDataProperty.Water, 0.5f },
        { FoodDataProperty.Alcohol, 0.0f },
        { FoodDataProperty.UltraProcessedProducts, 0.0f }
    };

    private static Dictionary<FoodDataProperty, float> propertyRecommendedMaxValues = new()
    {
        { FoodDataProperty.Carbohydrates, 0.6f },
        { FoodDataProperty.Lipids, 0.3f },
        { FoodDataProperty.Proteins, 0.2f },
        { FoodDataProperty.Fibers, 0.4f },
        { FoodDataProperty.Water, 0.6f },
        { FoodDataProperty.Alcohol, 0.0f },
        { FoodDataProperty.UltraProcessedProducts, 0.0f }
    };

    public FoodData()
    {
        name = "";
        carbohydrates = 0;
        lipids = 0;
        proteins = 0;
        fibers = 0;
        water = 0;
        alcohol = 0;
        ultraProcessedProducts = 0;
    }

    /// <summary>
    /// Returns the sum of the given foods data
    /// </summary>
    /// <param name="foodDataArray"> The array of food data </param>
    /// <returns> The sum of the given foods data </returns>
    public static FoodData TotalFromArray(FoodData[] foodDataArray)
    {
        FoodData totalData = new();
        for (int i = 0; i < foodDataArray.Length; i++)
        {
            totalData += foodDataArray[i];
        }
        totalData.name = "Total";
        return totalData;
    }

    public static FoodData operator +(FoodData a, FoodData b)
    {
        FoodData totalData = new()
        {
            name = a.name + " + " + b.name,
            carbohydrates = a.carbohydrates + b.carbohydrates,
            lipids = a.lipids + b.lipids,
            proteins = a.proteins + b.proteins,
            fibers = a.fibers + b.fibers,
            water = a.water + b.water,
            alcohol = a.alcohol + b.alcohol,
            ultraProcessedProducts = a.ultraProcessedProducts + b.ultraProcessedProducts
        };
        return totalData;
    }

    /// <summary>
    /// Returns the index of the food with the maximum value of the given property in the given array
    /// </summary>
    /// <param name="foodDataArray"> The array of food data </param>
    /// <param name="property"> The property to compare </param>
    /// <returns> The index of the food with the maximum value of the given property in the given array </returns>
    public static int GetMaxPropertyInArray(FoodData[] foodDataArray, FoodDataProperty property)
    {
        float max = 0;
        int maxIndex = 0;
        for (int i = 0; i < foodDataArray.Length; i++)
        {
            switch (property)
            {
                case FoodDataProperty.Carbohydrates:
                    if (foodDataArray[i].carbohydrates > max)
                    {
                        max = foodDataArray[i].carbohydrates;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.Lipids:
                    if (foodDataArray[i].lipids > max)
                    {
                        max = foodDataArray[i].lipids;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.Proteins:
                    if (foodDataArray[i].proteins > max)
                    {
                        max = foodDataArray[i].proteins;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.Fibers:
                    if (foodDataArray[i].fibers > max)
                    {
                        max = foodDataArray[i].fibers;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.Water:
                    if (foodDataArray[i].water > max)
                    {
                        max = foodDataArray[i].water;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.Alcohol:
                    if (foodDataArray[i].alcohol > max)
                    {
                        max = foodDataArray[i].alcohol;
                        maxIndex = i;
                    }
                    break;
                case FoodDataProperty.UltraProcessedProducts:
                    if (foodDataArray[i].ultraProcessedProducts > max)
                    {
                        max = foodDataArray[i].ultraProcessedProducts;
                        maxIndex = i;
                    }
                    break;
            }
        }
        return maxIndex;
    }

    public override string ToString()
    {
        return name + ":\n" +
            "Carbohydrates: " + carbohydrates + "\n" +
            "Lipids: " + lipids + "\n" +
            "Proteins: " + proteins + "\n" +
            "Fibers: " + fibers + "\n" +
            "Water: " + water + "\n" +
            "Alcohol: " + alcohol + "\n" +
            "Ultra-processed products: " + ultraProcessedProducts;
    }
}