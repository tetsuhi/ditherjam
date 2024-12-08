using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Player>().getRespawn().Equals(transform.position))
        {
            Debug.Log("nuevo respawn");
            collision.GetComponent<Player>().updateRespawn(transform.position);
        }
    }
}
