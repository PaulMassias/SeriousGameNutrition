using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField]
    private SlideBar carbohydratesSlideBar;
    [SerializeField]
    private SlideBar lipidsSlideBar;
    [SerializeField]
    private SlideBar proteinsSlideBar;
    [SerializeField]
    private SlideBar fibersSlideBar;
    [SerializeField]
    private SlideBar waterSlideBar;
    [SerializeField]
    private SlideBar alcoholSlideBar;
    [SerializeField]
    private SlideBar ultraProcessedProductsSlideBar;

    private void Start()
    {
        carbohydratesSlideBar.SetValue(0);
        lipidsSlideBar.SetValue(0);
        proteinsSlideBar.SetValue(0);
        fibersSlideBar.SetValue(0);
        waterSlideBar.SetValue(0);
        alcoholSlideBar.SetValue(0);
        ultraProcessedProductsSlideBar.SetValue(0);
    }

    public void UpdateSlideBar(FoodData foodData)
    {
        carbohydratesSlideBar.SetValue(foodData.carbohydrates);
        lipidsSlideBar.SetValue(foodData.lipids);
        proteinsSlideBar.SetValue(foodData.proteins);
        fibersSlideBar.SetValue(foodData.fibers);
        waterSlideBar.SetValue(foodData.water);
        alcoholSlideBar.SetValue(foodData.alcohol);
        ultraProcessedProductsSlideBar.SetValue(foodData.ultraProcessedProducts);
    }
}
