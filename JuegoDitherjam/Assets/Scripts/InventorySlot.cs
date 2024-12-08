using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
    , IPointerClickHandler
{
    public Image ingredientIcon;
    public string ingredientName;

    public void ClearSlot()
    {
        ingredientIcon.enabled = false;
    }

    public void DrawSlot(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            ClearSlot();
            return;
        }
        ingredientIcon.enabled = true;
        ingredientIcon.sprite = ingredient.GetSprite();
        ingredientName = ingredient.GetName();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<UIInventoryManager>()
            .SendToAlchemy(ingredientIcon, ingredientName);
    }

}
