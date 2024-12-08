using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float ACCELERATION_SMOOTHING = 100.0f;

    public Vector2 speed = new Vector2(0.5f, 0.25f);
    private GameObject player;
    private Rigidbody2D playerRB;
    private Vector2 targetVelocity;
    Vector2 respawnPosition;
    [SerializeField]
    private bool canMove;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        respawnPosition = player.transform.position;
        canMove = true;
    }

    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        FlipCharacter(horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        targetVelocity = direction * speed;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            playerRB.velocity = Vector2.Lerp(playerRB.velocity, targetVelocity, 1 - Mathf.Exp(-Time.deltaTime * ACCELERATION_SMOOTHING));
        }
        else
        {
            playerRB.velocity = Vector2.Lerp(playerRB.velocity, new Vector2(0.0f, 0.0f), 1 - Mathf.Exp(-Time.deltaTime * ACCELERATION_SMOOTHING));
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public Vector2 getRespawn()
    {
        return respawnPosition;
    }

    public void updateRespawn(Vector2 newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }

    public void Respawn()
    {
        player.transform.position = respawnPosition;
    }

    public bool GetPlayerMove()
    {
        return canMove;
    }

    public void SetPlayerMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
