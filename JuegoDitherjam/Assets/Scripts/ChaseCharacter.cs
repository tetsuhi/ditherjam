using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCharacter : MonoBehaviour
{
    [SerializeField]
    private bool isChasing;
    private GameObject player;
    private Vector2 desiredPosition;
    [SerializeField]
    private float speed = 1f;
    private Vector2 initialPosition;
    private Transform aliveNPC;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.parent.position;
        aliveNPC = transform.parent;
    }

    private void Update()
    {
        if (isChasing)
        {
            FlipCharacter();
            desiredPosition = player.transform.position;
            aliveNPC.position = Vector3.MoveTowards(aliveNPC.position, desiredPosition, speed * Time.deltaTime);
        }
        else
        {
            aliveNPC.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(aliveNPC.GetComponent<Rigidbody2D>().velocity,
                new Vector2(0, 0), speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name is "Player")
        {
            int random = Random.Range(0, 2);
            print(random);
            if (random == 0)
            {
                transform.parent.GetChild(2).GetComponent<AudioSource>().Play();
                isChasing = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name is "Player")
        {
            transform.parent.GetChild(2).GetComponent<AudioSource>().Stop();
            isChasing = false;
        }
    }

    private void FlipCharacter()
    {
        if(desiredPosition.x < aliveNPC.position.x)
        {
            aliveNPC.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (desiredPosition.x > aliveNPC.position.x)
        {
            aliveNPC.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void ResetToInitialPosition()
    {
        transform.parent.position = initialPosition;
    }
}
