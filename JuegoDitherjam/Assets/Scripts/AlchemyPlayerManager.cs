using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyPlayerManager : MonoBehaviour
{
    [SerializeField]
    private int fluid = 0;
    private Player player;
    private PlayerInventoryManager playerInventory;
    public GameObject alchemyMenu;
    public UIInventoryManager inventoryUI;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerInventory = player.GetComponentInChildren<PlayerInventoryManager>();
        inventoryUI = alchemyMenu.GetComponentInChildren<UIInventoryManager>();
    }

    private void Update()
    {
        OpenAlchemyMenu();
    }

    private void OpenAlchemyMenu()
    {
        if (Input.GetKeyDown(KeyCode.Q) && player.GetPlayerMove())
        {
            alchemyMenu.SetActive(!alchemyMenu.activeInHierarchy);
            inventoryUI.DrawInventory(playerInventory.GetInventory());
        }
    }

    public void AddFluid(int quantity)
    {
        fluid += quantity;
    }

    public void SpendFluid(int cost)
    {
        fluid -= cost;
    }

    public int GetFluid()
    {
        return fluid;
    }
}
