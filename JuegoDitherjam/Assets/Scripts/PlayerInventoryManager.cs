using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<Ingredient> inventory = new List<Ingredient>();

    public void DeleteRandomIngredient()
    {
        if (inventory.Count > 0)
        {
            int randomIndex = Random.Range(0, inventory.Count);
            inventory.RemoveAt(randomIndex);
        }
    }

    public Ingredient GetFirstItem()
    {
        if (inventory.Count <= 0)
        {
            return null;
        }
        else
        {
            Ingredient firstIngredient = inventory[0];
            inventory.RemoveAt(0);
            return firstIngredient;
        }
    }

    public Sprite GetItemSprite(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            return inventory[index].GetSprite();
        }
        else
        {
            return null;
        }
    }

    public void AddToInventory(Ingredient newIngredient)
    {
        inventory.Add(newIngredient);
    }
    
    public List<Ingredient> GetInventory()
    {
        return inventory;
    }
}
