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
    [SerializeField]
    private string ingredientName;
    public GameObject inventoryManager;
    private UIInventoryManager uIInventoryManager;
    [SerializeField]
    private GameObject ingredientPrefab;

    void Start()
    {
        uIInventoryManager = inventoryManager.GetComponent<UIInventoryManager>();
    }

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

    public void SetPrefab(GameObject ingredientPrefab)
    {
        this.ingredientPrefab = ingredientPrefab;
    }

    public bool GetIngredientAdded()
    {
        return ingredientAdded;
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }

    void ResetSlot()
    {
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        ingredientName = "";
        ingredientAdded = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        uIInventoryManager.RestoreIngredient(ingredientPrefab);
        ResetSlot();
    }
}
