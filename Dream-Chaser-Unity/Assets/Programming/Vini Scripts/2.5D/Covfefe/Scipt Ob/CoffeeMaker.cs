using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee;
public class CoffeeMaker : MonoBehaviour
{
    public Coffee.Recipe.CookingMethod cookingMethod = Recipe.CookingMethod.Machine;
    CoffeeManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoffeeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cup"))
        {
            manager.currentRecipe.cookingMethod = cookingMethod;
            return;
        }
        Ingredients ingredients = collision.GetComponent<IngredientManager>().ingredient;
        if(ingredients)
        {
            manager.AddIngredient(ingredients);
        }
    }
}
