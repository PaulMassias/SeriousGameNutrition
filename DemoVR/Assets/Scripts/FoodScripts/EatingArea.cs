using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EatingArea : MonoBehaviour
{
    public delegate void FruitDataDelegate(FoodData foodData);
    public event FruitDataDelegate OnFruitEaten;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.TryGetComponent(out Food food))
        {
            EatFood(food);
        }
    }

    private void EatFood(Food food)
    {
        Debug.Log(food.ToString() + " eaten");
        if (food.foodData != null)
        {
            OnFruitEaten?.Invoke(food.foodData);
        }
        else
        {
            Debug.LogError("Error while getting food data: foodData is null.");
        }
        if (food.gameObject.TryGetComponent(out InteractableFacade interactableFacade))
        {
            interactableFacade.UngrabAll();
        }
        audioSource.Play();
        Destroy(food.gameObject);
    }
}
