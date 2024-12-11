using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyPlayerManager : MonoBehaviour
{
    [SerializeField]
    private bool fluid;
    private Player player;
    //private PlayerInventoryManager playerInventory;
    public GameObject alchemyMenu;
    public GameObject grimoireMenu;
    public UIInventoryManager inventoryUI;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //playerInventory = player.GetComponentInChildren<PlayerInventoryManager>();
        inventoryUI = alchemyMenu.GetComponentInChildren<UIInventoryManager>();
    }

    private void Update()
    {
        OpenAlchemyMenu();
    }

    private void OpenAlchemyMenu()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.GetPlayerMove() && !grimoireMenu.activeInHierarchy)
        {
            alchemyMenu.SetActive(!alchemyMenu.activeInHierarchy);
            player.SetOpenedMenu(alchemyMenu.activeInHierarchy);
            inventoryUI.DrawInventory(player.GetComponentInChildren<PlayerInventoryManager>().GetInventory());
        }
    }

    public void AddFluid()
    {
        fluid = true;
    }

    public void SpendFluid()
    {
        fluid = false;
    }

    public bool GetFluid()
    {
        return fluid;
    }
}
