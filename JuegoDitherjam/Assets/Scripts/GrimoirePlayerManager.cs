using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoirePlayerManager : MonoBehaviour
{
    public GameObject grimoireMenu;
    public GameObject alchemyMenu;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        OpenGrimoire();
    }

    void OpenGrimoire()
    {
        if (Input.GetKeyDown(KeyCode.Q) && player.GetPlayerMove() && !alchemyMenu.activeInHierarchy)
        {
            if (!grimoireMenu.activeInHierarchy)
            {
                transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            else
            {
                transform.GetChild(1).GetComponent<AudioSource>().Play();
            }
            grimoireMenu.SetActive(!grimoireMenu.activeInHierarchy);
            player.SetOpenedMenu(grimoireMenu.activeInHierarchy);
        }
    }
}
