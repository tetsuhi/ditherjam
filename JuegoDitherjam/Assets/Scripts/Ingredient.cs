using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private string ingredientName;
    [SerializeField]
    private Image ingredientTexture;
    [SerializeField]
    private GameObject ingredientPrefab;
    [SerializeField]
    private Image tattooLinked;

    public void SetSprite(Image ingredientTexture)
    {
        this.ingredientTexture = ingredientTexture;
    }

    public Image GetSprite()
    {
        return ingredientTexture;
    }
        public void SetName(string ingredientName)
    {
        this.ingredientName = ingredientName;
    }

    public string GetName()
    {
        return ingredientName;
    }

    public void SetPrefab(GameObject ingredientPrefab)
    {
        this.ingredientPrefab = ingredientPrefab;
    }

    public GameObject GetPrefab()
    {
        return ingredientPrefab;
    }

    public void SetTattoo(Image tattooLinked)
    {
        this.tattooLinked = tattooLinked;
    }

    public Image GetTattoo()
    {
        return tattooLinked;
    }
}
