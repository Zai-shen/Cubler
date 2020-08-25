using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private Score scoreComponent;

    private void Start()
    {
        scoreComponent = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Trigger collided with tag: " + other.tag + " increasing score");
            scoreComponent.increaseScore(1f);
        }

        if (other.CompareTag("DestroyTrigger"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

}
