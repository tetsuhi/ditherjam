using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDeadInteraction : MonoBehaviour
{
    private const float BASE_TIME = 10.0f;

    private GameObject menuIndicator;
    [SerializeField]
    private GameObject lootMenu;
    private GameObject player;
    private GameObject ingredientMenu;
    private GameObject tattooMenu;

    [SerializeField]
    private float targetTime = BASE_TIME;
    [SerializeField]
    private bool canReceiveIngredient = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        menuIndicator = transform.parent.GetChild(1).gameObject;
        ingredientMenu = lootMenu.transform.GetChild(2).gameObject;
        tattooMenu = lootMenu.transform.GetChild(1).gameObject;
        tattooMenu.GetComponent<Image>().sprite = transform.parent.GetComponent<PlayerInventoryManager>().GetItemTattooSprite(0);
    }

    void Update()
    {
        OpenMenu();
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            canReceiveIngredient = true;
            ShowIngredient();
        }
    }

    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.F) && menuIndicator.activeInHierarchy)
        {
            transform.parent.GetChild(2).GetComponent<AudioSource>().Play();
            if (lootMenu.activeInHierarchy && canReceiveIngredient)
            {
                GameObject deadGuyInventoryItem = transform.parent.GetComponent<PlayerInventoryManager>().GetFirstItem();
                player.GetComponentInChildren<PlayerInventoryManager>().AddToInventory(deadGuyInventoryItem);
                canReceiveIngredient = false;
                HideIngredient();
                RestartTimer();
            }
            if (!lootMenu.activeInHierarchy)
            {
                ingredientMenu.GetComponent<Image>().sprite = transform.parent.GetComponent<PlayerInventoryManager>().GetItemSprite(0);
            }
            player.GetComponent<Player>().SetPlayerMove(lootMenu.activeInHierarchy);
            lootMenu.SetActive(!lootMenu.activeInHierarchy);
        }
    }

    private void RestartTimer()
    {
        targetTime = BASE_TIME;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuIndicator.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuIndicator.SetActive(false);
    }

    private void HideIngredient()
    {
        ingredientMenu.SetActive(false);
    }

    private void ShowIngredient()
    {
        ingredientMenu.SetActive(true);
    }
}
