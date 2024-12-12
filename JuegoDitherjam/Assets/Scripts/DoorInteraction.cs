using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject doorRequirementIndicator;
    [SerializeField]
    private GameObject ingredientRequired;
    private string ingredientRequiredName;
    [SerializeField]
    private GameObject playerInventory;
    private PlayerInventoryManager playerInventoryManager;
    private bool playerInRange;

    private void Start()
    {
        playerInventoryManager = playerInventory.GetComponent<PlayerInventoryManager>();
        ingredientRequiredName = ingredientRequired.GetComponent<Ingredient>().GetName();
    }

    private void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerInRange)
        {
            int ingredientInventoryIndex = playerInventoryManager.FindItemByName(ingredientRequiredName);
            if (ingredientInventoryIndex != -1)
            {
                playerInventoryManager.DeleteIngredientPosition(ingredientInventoryIndex);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name is "Player")
        {
            playerInRange = true;
            doorRequirementIndicator.GetComponent<SpriteRenderer>().sprite = ingredientRequired.GetComponent<Ingredient>().GetSprite().sprite;
            doorRequirementIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name is "Player")
        {
            playerInRange = false;
            doorRequirementIndicator.SetActive(false);
        }
    }
}
