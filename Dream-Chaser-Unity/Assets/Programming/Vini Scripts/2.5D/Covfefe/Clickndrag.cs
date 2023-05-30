using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Coffee;
using TMPro;

public class Clickndrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Sprite[] sprites;
    public Image spriteRenderer;
    public float timeBeforeFadein;
    public GameObject HoverBox;
    public Vector2 Offset;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spriteRenderer = gameObject.GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[1];
        }
       // Debug.Log("pointer Click");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //Debug.Log("Dragon");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //spriteRenderer.sprite = sprites[1];
        //Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[1];
        }
        //Debug.Log("Dragoff");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");

            Debug.Log(eventData.hovered.Count);
            Ingredients currentIngred = eventData.pointerEnter.GetComponent<IngredientManager>().ingredient;


            StartCoroutine(DescriptionTimer(timeBeforeFadein));

            if (currentIngred != null)
            {
                HoverBox.SetActive(true);
                HoverBox.transform.position = eventData.pointerEnter.transform.position + new Vector3(Offset.x, Offset.y);
                HoverBox.GetComponentInChildren<TextMeshProUGUI>().text = currentIngred.description;
            }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverBox.SetActive(false);
        
    }

    IEnumerator DescriptionTimer(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);
    }
}
