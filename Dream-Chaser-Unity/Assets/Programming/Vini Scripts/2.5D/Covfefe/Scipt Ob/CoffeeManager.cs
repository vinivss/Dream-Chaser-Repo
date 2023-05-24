using Coffee;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoffeeManager : MonoBehaviour
{
    public RecipeBook recipeBook;
    public Recipe currentRecipe;
    public Recipe CookedRecipe;
    public Transform drinkSpawnPoint;

    private void Awake()
    {
        currentRecipe =  ScriptableObject.CreateInstance("Recipe") as Recipe;
       
    }
    public void OnCook()
    {
        foreach(Recipe r in recipeBook.recipes)
        {
            if(r.cookingMethod == currentRecipe.cookingMethod)
            {
                if(r.RecipeIngreds == currentRecipe.RecipeIngreds)
                {
                    CookedRecipe = r;
                    break;
                }
            }
        }
    }
    public void AddIngredient(Ingredients ingredient)
    {

        foreach(Recipe.RecipeIngredients i in currentRecipe.RecipeIngreds)
        {
            if(i.ingredientsNeeded.GetType() == ingredient.GetType())
            {
                var ingredneed = i;
                ingredneed.ingredientsCount += 1;
                return;
            }
        }
        Recipe.RecipeIngredients recipeIngredients = new Recipe.RecipeIngredients();
        recipeIngredients.ingredientsNeeded = ingredient;
        recipeIngredients.ingredientsCount += 1;
        currentRecipe.RecipeIngreds.Add(recipeIngredients);
        Debug.Log(currentRecipe.RecipeIngreds.Count);
    }
}
