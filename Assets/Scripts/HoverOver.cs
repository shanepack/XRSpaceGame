using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform textTransform;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = textTransform.localScale; // Store original size
    }

    public void OnPointerEnter(PointerEventData eventData) {
        textTransform.localScale = originalScale * 1.2f; // Inc the size
        Console.Write("Mouse detected!");
    }

    public void OnPointerExit(PointerEventData eventData) {
        textTransform.localScale = originalScale; // Revert to OG size
    }
}
