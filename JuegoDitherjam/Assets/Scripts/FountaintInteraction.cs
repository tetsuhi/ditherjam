using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountaintInteraction : MonoBehaviour
{
    private const float BASE_TIME = 60.0f;

    [SerializeField]
    private GameObject menuIndicator;
    private GameObject player;
    [SerializeField]
    private float targetTime = BASE_TIME;
    [SerializeField]
    private bool canReceiveFluid = true;

    void Start()
    {
        //menuIndicator = transform.parent.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
        ReceiveFluid();
    }

    private void TimerEnded()
    {
        canReceiveFluid = true;
    }

    private void RestartTimer()
    {
        targetTime = BASE_TIME;
    }

    private void ReceiveFluid()
    {
        if (Input.GetKeyDown(KeyCode.F) && menuIndicator.activeInHierarchy && canReceiveFluid)
        {
            transform.GetChild(0).GetComponent<AudioSource>().Play();
            canReceiveFluid = false;
            RestartTimer();
            player.GetComponentInChildren<AlchemyPlayerManager>().AddFluid();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuIndicator.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuIndicator.SetActive(false);
    }
}
