using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCharacter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name is "Player")
        {
            collision.GetComponentInChildren<PlayerInventoryManager>().DeleteRandomIngredient();
            collision.GetComponent<Player>().Respawn();
            transform.parent.GetChild(1).GetComponent<ChaseCharacter>().ResetToInitialPosition();
        }
    }
}
