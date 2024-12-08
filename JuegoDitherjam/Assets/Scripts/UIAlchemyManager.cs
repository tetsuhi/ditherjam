using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlchemyManager : MonoBehaviour
{
    private PlayerInventoryManager playerInventory;
    private int playerFluid;
    [SerializeField]
    private GameObject firstIngredientMix;
    [SerializeField]
    private GameObject secondIngredientMix;
    [SerializeField]
    private GameObject resultMix;

    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<PlayerInventoryManager>();
        playerFluid = GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<AlchemyPlayerManager>().GetFluid();

        firstIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        secondIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        resultMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

    public void SetNewIngredient(Image ingredientImage, string ingredientName)
    {
        if (!firstIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientAdded())
        {
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetImage(ingredientImage);
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetName(ingredientName);
            firstIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        else if (!secondIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientAdded())
        {
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetImage(ingredientImage);
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetName(ingredientName);
            secondIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }

}
