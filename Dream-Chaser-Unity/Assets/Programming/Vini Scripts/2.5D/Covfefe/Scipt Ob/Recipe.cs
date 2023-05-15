

using System;
using System.Collections.Generic;
using UnityEngine;


namespace Coffee
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Coffee/New Recipe")]
    public class Recipe : ScriptableObject
    {

        public enum CookingMethod
        {
            Siphon,
            Machine,
            Kettle
        }
        //public List<Ingredients> ingreds;

        //public List<Ingredients> IngredientAmount;
        [Serializable]
        public struct RecipeIngredients
        {
            public Ingredients ingredientsNeeded;
            public int ingredientsCount;        
        }
        [Header("Ingredients :")]
        public RecipeIngredients[] RecipeIngreds;
        [Header("CookingMethod")]
        public CookingMethod cookingMethod;
        [Header("Sprite")]
        public Sprite Sprite;



    }
}
