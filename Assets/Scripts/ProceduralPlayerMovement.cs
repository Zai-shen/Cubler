using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralPlayerMovement : MonoBehaviour
{
    // This line does not only represent a variable, but also enables the input field to be shown in unity.
    public Rigidbody rb;

    public float sidewaysSpeed = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {

        // Instant response movement
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, sidewaysSpeed / 2 * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}