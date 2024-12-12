using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlchemyManager : MonoBehaviour
{
    private PlayerInventoryManager playerInventory;
    public bool playerFluid;
    [SerializeField]
    private GameObject firstIngredientMix;
    [SerializeField]
    private GameObject secondIngredientMix;
    [SerializeField]
    private GameObject resultMix;
    [SerializeField]
    private Button alchemyButton;
    [SerializeField]
    private List<GameObject> resultsList = new List<GameObject>();

    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<PlayerInventoryManager>();

        firstIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        secondIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        resultMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        alchemyButton.onClick.AddListener(OnAlchemyButtonClick);
    }

    public void SetNewIngredient(Image ingredientImage, string ingredientName, GameObject ingredientPrefab)
    {
        if (!firstIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientAdded())
        {
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetImage(ingredientImage);
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetName(ingredientName);
            firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetPrefab(ingredientPrefab);
            firstIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        else if (!secondIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientAdded())
        {
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetImage(ingredientImage);
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetName(ingredientName);
            secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetPrefab(ingredientPrefab);
            secondIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }

    public void OnAlchemyButtonClick()
    {
        playerFluid = GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<AlchemyPlayerManager>().GetFluid();

        if (playerFluid)
        {
            CheckResultantComponent(firstIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientName()
                , secondIngredientMix.GetComponent<AlchemyIngredientSlot>().GetIngredientName());
        }
        else
        {
            Debug.Log("va a transmutar tu madre");
        }
    }

    void CheckResultantComponent(string firstIngredientName, string secondIngredientName)
    {
        if ((firstIngredientName == "Kiwi" && secondIngredientName == "Manzana") 
            || (firstIngredientName == "Manzana" && secondIngredientName == "Kiwi"))
        {
            GameObject resultantComponent = Instantiate(resultsList[0]);
            resultMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetImage(resultsList[0].GetComponent<Ingredient>().GetSprite());
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetName(resultsList[0].GetComponent<Ingredient>().GetName());
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetPrefab(resultsList[0]);
            resultMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
            DeleteIngredients();
            transform.parent.GetChild(2).GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<AlchemyPlayerManager>().SpendFluid();
        }

        if ((firstIngredientName == "Plátano" && secondIngredientName == "Piña")
            || (firstIngredientName == "Piña" && secondIngredientName == "Plátano"))
        {
            GameObject resultantComponent = Instantiate(resultsList[1]);
            resultMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(true);
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetImage(resultsList[1].GetComponent<Ingredient>().GetSprite());
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetName(resultsList[1].GetComponent<Ingredient>().GetName());
            resultMix.GetComponent<AlchemyIngredientSlot>()
                .SetPrefab(resultsList[1]);
            resultMix.transform.GetChild(0).GetComponent<Image>().enabled = true;
            DeleteIngredients();
            transform.parent.GetChild(2).GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<AlchemyPlayerManager>().SpendFluid();
        }
    }

    void DeleteIngredients()
    {
        firstIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(false);
        firstIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
        secondIngredientMix.GetComponent<AlchemyIngredientSlot>().SetIngredientAdded(false);
        secondIngredientMix.transform.GetChild(0).GetComponent<Image>().enabled = false;
    }
}
