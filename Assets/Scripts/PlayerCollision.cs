using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public Rigidbody playerRB;

    private void OnCollisionEnter(Collision collision)
    {
        // Notify of hit with obstacle and stop movement
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Player hits: " + collision.collider.name);
            movement.enabled = false;
            collision.rigidbody.useGravity = false;
            playerRB.useGravity = false;
            FindObjectOfType<AudioManager>().Play("PlayerCrashed");
            FindObjectOfType<GameManager>().EndGame();
        }

    }

}
