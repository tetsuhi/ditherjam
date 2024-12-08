using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlchemyIngredientSlot : MonoBehaviour
    , IPointerClickHandler
{
    //enum AlchemyPosition
    //{
    //    Ingredient,
    //    Result
    //}

    private bool ingredientAdded;
    private Image ingredientIcon;
    private string ingredientName;
    [SerializeField]
    //private AlchemyPosition ingredientPosition;

    public void SetImage(Image ingredientIcon)
    {
        this.ingredientIcon = ingredientIcon;
        transform.GetChild(0).GetComponent<Image>().sprite = ingredientIcon.sprite;
    }
    public void SetName(string ingredientName)
    {
        this.ingredientName = ingredientName;
    }

    public void SetIngredientAdded(bool ingredientAdded)
    {
        this.ingredientAdded = ingredientAdded;
    }

    public bool GetIngredientAdded()
    {
        return ingredientAdded;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("me han clickado para quitarme!");
    }
}
