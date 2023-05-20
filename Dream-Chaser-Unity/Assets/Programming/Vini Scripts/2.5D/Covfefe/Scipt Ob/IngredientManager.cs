using Coffee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public Ingredients ingredient;
    [HideInInspector]public string DisplayName;
    [HideInInspector]public string Description;
    // Start is called before the first frame update
    void Start()
    {
        if (ingredient != null)
        {
            DisplayName = ingredient.IngredientName;
            Description = ingredient.description;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
