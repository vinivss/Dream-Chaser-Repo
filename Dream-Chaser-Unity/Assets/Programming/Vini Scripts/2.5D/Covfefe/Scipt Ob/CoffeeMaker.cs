using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee;
public class CoffeeMaker : MonoBehaviour
{
    public Coffee.Recipe.CookingMethod cookingMethod = Recipe.CookingMethod.Machine;
    CoffeeManager manager;
    public Transform CompleteWaypoint;

    public GameObject[] Arrows;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoffeeManager>();
        Arrows = manager.Arrows;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN");
        if (collision.CompareTag("Cup"))
        {
            foreach (GameObject arrow in Arrows)
            {
                arrow.SetActive(false);
            }
            manager.currentRecipe.cookingMethod = cookingMethod;
            Clickndrag clickndrag = collision.GetComponent<Clickndrag>();
            clickndrag.enabled = false;
            manager.drinkSpawnPoint = CompleteWaypoint;
            collision.transform.position = CompleteWaypoint.transform.position;
            collision.transform.SetAsLastSibling();
            CanvasGroup Coll = collision.GetComponent<CanvasGroup>();
           
            if (Coll != null)
                Coll.interactable = false;
            return;
        }
        else
        {
            Ingredients ingredients = collision.GetComponent<IngredientManager>().ingredient;
            if (ingredients != null)
            {
                manager.AddIngredient(ingredients);
                Destroy(collision.gameObject);
            }
        }
    }
}
