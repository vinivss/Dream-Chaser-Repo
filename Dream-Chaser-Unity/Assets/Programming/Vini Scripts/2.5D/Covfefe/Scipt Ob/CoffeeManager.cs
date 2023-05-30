using Coffee;
using System;
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
    GameManager manager;

    private void Awake()
    {
        currentRecipe =  ScriptableObject.CreateInstance("Recipe") as Recipe;
        manager = FindObjectOfType<GameManager>();
       
    }
    public void OnCook()
    {
        foreach(Recipe r in recipeBook.recipes)
        {
            if(r.cookingMethod == currentRecipe.cookingMethod)
            {
               
                if(CheckIngredients(r))
                {
                    Debug.Log("Coooked");
                    CookedRecipe = r;
                    Debug.Log(CookedRecipe.name);
                    manager.CurrentCarryingRecipe = CookedRecipe;
                    break;
                }
            }
        }
    }

    private bool CheckIngredients(Recipe recipeToCheck)
    {
        if(recipeToCheck.RecipeIngreds.Count != currentRecipe.RecipeIngreds.Count)
        {
            return false;
        }
        recipeToCheck.RecipeIngreds.Sort();
        currentRecipe.RecipeIngreds.Sort();

        for (int i = 0; i < recipeToCheck.RecipeIngreds.Count; i++)
        {
            if (recipeToCheck.RecipeIngreds[i].ingredientsNeeded != currentRecipe.RecipeIngreds[i].ingredientsNeeded || recipeToCheck.RecipeIngreds[i].ingredientsCount != currentRecipe.RecipeIngreds[i].ingredientsCount)
            {
                return false;
            }
        }
        return true;

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
