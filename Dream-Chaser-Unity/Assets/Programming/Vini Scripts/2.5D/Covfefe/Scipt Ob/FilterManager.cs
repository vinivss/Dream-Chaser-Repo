using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class FilterManager : MonoBehaviour
{
    CoffeeManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoffeeManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ingredients ingredients = collision.GetComponent<IngredientManager>().ingredient;
        if (ingredients != null)
        {
            manager.AddIngredient(ingredients);
            Clickndrag drag = collision.GetComponent<Clickndrag>();
            collision.transform.position = drag.startPos;
            drag.Starting = false;
            drag.isDraggin = false;

        }
    }
}
