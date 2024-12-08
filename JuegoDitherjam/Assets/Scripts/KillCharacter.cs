using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCharacter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInChildren<PlayerInventoryManager>().DeleteRandomIngredient();
        collision.GetComponent<Player>().Respawn();
    }
}
