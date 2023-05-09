using Coffee;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoffeeManager : MonoBehaviour
{
    public RecipeBook recipeBook;
    Recipe currentRecipe;
    [HideInInspector]public Recipe CookedRecipe;

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
        int j = 0;
        if(currentRecipe.RecipeIngreds.Length == 0)
        {
            currentRecipe.RecipeIngreds[0].ingredientsNeeded = ingredient;
            currentRecipe.RecipeIngreds[0].ingredientsCount += 1;

        }
        foreach(Recipe.RecipeIngredients i in currentRecipe.RecipeIngreds)
        {
            if(i.ingredientsNeeded.GetType() == ingredient.GetType())
            {
                currentRecipe.RecipeIngreds[j].ingredientsCount += 1;
                break;
            }
            j++;
        }
        Recipe.RecipeIngredients recipeIngredients = new Recipe.RecipeIngredients();
        recipeIngredients.ingredientsNeeded = ingredient;
        recipeIngredients.ingredientsCount += 1;
        currentRecipe.RecipeIngreds.Append(recipeIngredients);
    }
}
