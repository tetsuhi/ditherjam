using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(12);
    public UIAlchemyManager alchemyManager;
    private PlayerInventoryManager playerInventoryManager;
    

    private void Start()
    {
        playerInventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
        DrawInventory(playerInventoryManager.GetInventory());
    }

    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(12);
    }

    public void DrawInventory(List<GameObject> ingredientPlayerList)
    {
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < ingredientPlayerList.Count; i++)
        {
            inventorySlots[i].DrawSlot(ingredientPlayerList[i], i);
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }

    public void SendToAlchemy(Image ingredientImage, string ingredientName, GameObject ingredientPrefab)
    {
        alchemyManager.SetNewIngredient(ingredientImage, ingredientName, ingredientPrefab);
    }

    public void DeleteIngredientInInventory(int index)
    {
        playerInventoryManager.DeleteIngredientPosition(index);
        DrawInventory(playerInventoryManager.GetInventory());
    }

    public void RestoreIngredient(GameObject ingredient)
    {
        playerInventoryManager.AddToInventory(ingredient);
        DrawInventory(playerInventoryManager.GetInventory());
    }
}
