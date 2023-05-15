using Coffee;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Recipe Book", menuName = "Coffee/Create Recipe Book")]
public class RecipeBook : ScriptableObject
{
    public List<Recipe> recipes;
#if UNITY_EDITOR
    private void OnEnable()
    {
        recipes = GetAllInstances<Recipe>();
    }

    public static List<T> GetAllInstances<T>() where T : Recipe
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a.ToList<T>();


    }
#endif
}
