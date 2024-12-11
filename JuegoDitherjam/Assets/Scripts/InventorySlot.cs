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
    public GameObject ingredientPrefab;
    public int itemListPosition;

    public void ClearSlot()
    {
        ingredientIcon.enabled = false;
    }

    public void DrawSlot(GameObject ingredient, int position)
    {
        if (ingredient == null)
        {
            ClearSlot();
            return;
        }
        ingredientIcon.enabled = true;
        ingredientIcon.sprite = ingredient.GetComponent<Ingredient>().GetSprite().sprite;
        ingredientName = ingredient.GetComponent<Ingredient>().GetName();
        ingredientPrefab = ingredient.GetComponent<Ingredient>().GetPrefab();
        itemListPosition = position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(ingredientName != "")
        {
            transform.parent.GetComponent<UIInventoryManager>()
            .SendToAlchemy(ingredientIcon, ingredientName, ingredientPrefab);
            transform.parent.GetComponent<UIInventoryManager>()
                .DeleteIngredientInInventory(itemListPosition);
        }
    }

}
