using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickndrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Sprite[] sprites;
    public Image spriteRenderer;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spriteRenderer = gameObject.GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        spriteRenderer.sprite = sprites[1];
        Debug.Log("pointer Click");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("Dragon");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //spriteRenderer.sprite = sprites[1];
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        spriteRenderer.sprite = sprites[1];
        Debug.Log("Dragoff");
        canvasGroup.blocksRaycasts = true;
    }

}
