using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee;
using UnityEngine.UI;


public class ChangeToFullFilter : MonoBehaviour
{
    CoffeeManager manager;
    public GameObject Filter;
    public Sprite full;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoffeeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.currentRecipe != null)
        if(manager.currentRecipe.RecipeIngreds.Count > 0 && done == false )
        {
            Filter.GetComponent<Image>().sprite = full;
            done = true;
        }
    }
}
