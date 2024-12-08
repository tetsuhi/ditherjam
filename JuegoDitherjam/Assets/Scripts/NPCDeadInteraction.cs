using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeadInteraction : MonoBehaviour
{
    private GameObject menuIndicator;
    [SerializeField]
    private GameObject lootMenu;
    private GameObject player;
    private GameObject ingredientMenu;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        menuIndicator = transform.parent.GetChild(1).gameObject;
        ingredientMenu = lootMenu.transform.GetChild(2).gameObject;
    }

    void Update()
    {
        OpenMenu();
    }

    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuIndicator.activeInHierarchy)
        {
            if (lootMenu.activeInHierarchy)
            {
                Ingredient deadGuyInventoryItem = transform.parent.GetComponent<PlayerInventoryManager>().GetFirstItem();
                player.GetComponentInChildren<PlayerInventoryManager>().AddToInventory(deadGuyInventoryItem);
            }
            player.GetComponent<Player>().SetPlayerMove(lootMenu.activeInHierarchy);
            lootMenu.SetActive(!lootMenu.activeInHierarchy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuIndicator.SetActive(true);
        ingredientMenu.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<PlayerInventoryManager>().GetItemSprite(0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuIndicator.SetActive(false);
    }
}
