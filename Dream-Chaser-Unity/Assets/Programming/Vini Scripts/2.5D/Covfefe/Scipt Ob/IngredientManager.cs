using Coffee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public Ingredients ingredient;
    public string DisplayName;
    public string Description;
    // Start is called before the first frame update
    void Start()
    {
        DisplayName = ingredient.name;
        Description = ingredient.description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
