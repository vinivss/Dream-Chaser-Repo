using Coffee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeManager : MonoBehaviour
{
    public RecipeBook recipeBook;
    public Recipe currentRecipe;
    public Recipe CookedRecipe;
    public Transform drinkSpawnPoint;
    GameManager manager;
    public GameObject[] Arrows;
    public GameObject WinningBanner;
    public TextMeshProUGUI WinningNameText;
    public Image bannerimg;
    [Header("Cam Shake")]
    Camera cam;
    public AnimationCurve curve;
    public float duration = 1f;
    

    private void Awake()
    {
        cam = Camera.main;
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
                    WinningBanner.SetActive(true);
                    bannerimg.sprite = CookedRecipe.Sprite;
                    WinningNameText.text = CookedRecipe.name;
                    
                    return;
                }
            }
        }

        CookingFailure();
        currentRecipe = null;
        currentRecipe = ScriptableObject.CreateInstance("Recipe") as Recipe;
        CoffeeMaker coffee = FindObjectOfType<CoffeeMaker>();
        coffee.ResetMachine();
    }

    private void CookingFailure()
    {
        StartCoroutine(Shakin());
    }
    IEnumerator Shakin()
    {
        Vector3 startPos = cam.transform.position;
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            cam.transform.position = startPos + UnityEngine.Random.insideUnitSphere * strength;
            yield return null;
        }

        cam.transform.position = startPos;
    }
    private bool CheckIngredients(Recipe recipeToCheck)
    {
        if(recipeToCheck.RecipeIngreds.Count != currentRecipe.RecipeIngreds.Count)
        {
            return false;
        }


        for (int i = 0; i < recipeToCheck.RecipeIngreds.Count; i++)
        {
            if (currentRecipe.RecipeIngreds.Contains(recipeToCheck.RecipeIngreds[i]))
            {
                Recipe.RecipeIngredients temp = recipeToCheck.RecipeIngreds[i];
                if (currentRecipe.RecipeIngreds[currentRecipe.RecipeIngreds.IndexOf(temp)].ingredientsCount == temp.ingredientsCount)
                {
                    return true;
                }
                
            }
        }
        return false;

    }

    public void AddIngredient(Ingredients ingredient)
    {
        foreach(Recipe.RecipeIngredients i in currentRecipe.RecipeIngreds)
        {
            if(i.ingredientsNeeded.IngredientName == ingredient.IngredientName)
            {
                Recipe.RecipeIngredients temp = i;
                temp.ingredientsCount++;
                currentRecipe.RecipeIngreds.RemoveAt(currentRecipe.RecipeIngreds.IndexOf(i));
                currentRecipe.RecipeIngreds.Add(temp);
                return;
            }
        }
        Recipe.RecipeIngredients recipeIngredients = new Recipe.RecipeIngredients();
        recipeIngredients.ingredientsNeeded = ingredient;
        recipeIngredients.ingredientsCount += 1;
        currentRecipe.RecipeIngreds.Add(recipeIngredients);
        Debug.Log(currentRecipe.RecipeIngreds.Count);
    }

    private  void AddNewIngred(int i)
    {
        
    }
}
