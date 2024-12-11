using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> inventory = new List<GameObject>();

    public void DeleteRandomIngredient()
    {
        if (inventory.Count > 0)
        {
            int randomIndex = Random.Range(0, inventory.Count);
            inventory.RemoveAt(randomIndex);
        }
    }

    public GameObject GetFirstItem()
    {
        if (inventory.Count <= 0)
        {
            return null;
        }
        else
        {
            //GameObject firstIngredient = inventory[0];
            //inventory.RemoveAt(0);
            return inventory[0];
        }
    }

    public Sprite GetItemSprite(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            return inventory[index].GetComponent<Ingredient>().GetSprite().sprite;
        }
        else
        {
            return null;
        }
    }

    public Sprite GetItemTattooSprite(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            return inventory[index].GetComponent<Ingredient>().GetTattoo().sprite;
        }
        else
        {
            return null;
        }
    }

    public void AddToInventory(GameObject newIngredient)
    {
        inventory.Add(newIngredient);
    }
    
    public List<GameObject> GetInventory()
    {
        return inventory;
    }

    public void DeleteIngredientPosition(int index)
    {
        inventory.RemoveAt(index);
    }

    public int FindItemByName(string ingredientName)
    {
        int index = 0;
        while (index < inventory.Count)
        {
            if (inventory[index].GetComponent<Ingredient>().GetName() == ingredientName)
            {
                return index;
            }
            index++;
        }
        return -1;
    }
}
