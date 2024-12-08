using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private string ingredientName;
    [SerializeField]
    private Sprite ingredientTexture;

    //public Ingredient(string ingredientName, Texture2D ingredientTexture)
    //{
    //    this.ingredientName = ingredientName;
    //    this.ingredientTexture = ingredientTexture;
    //}
    //private void Start()
    //{
    //    GetComponent<SpriteRenderer>().sprite = ingredientTexture;
    //}
    public Sprite GetSprite()
    {
        return ingredientTexture;
    }
    public string GetName()
    {
        return ingredientName;
    }
}
