using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLineSpawning : MonoBehaviour
{
    [Header("Initial")]
    public GameObject lineObjectToSpawn;
    public float levelSpeed;
    public float levelDuration;
    public float initialSpawnDelay;

    [Header("Continuous")]
    [Range(0.5f,10f)]
    public float continuousSpawnDelay;
    [Range(0f,1000f)]
    public float additionalLevelSpeed;
    [Range(0f,1f)]
    public float lessSpawnDelay;

    private List<GameObject> spawnedLines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnNewLine(i);
        }

        StartCoroutine(RepeatSpawning());
        StartCoroutine(ChangeSpawning());
    }

    private void SpawnNewLine()
    {
        //Debug.Log("Spawning new line");
        GameObject newLine = Instantiate(lineObjectToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newLine.GetComponent<ProceduralLine>().lineSpeed = levelSpeed;
        spawnedLines.Add(newLine);
    }

    private void SpawnNewLine(int i)
    {
        //Debug.Log("Spawning new line with distance: " + i);
        GameObject newLine = Instantiate(lineObjectToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z - 30 + 15 * i), Quaternion.identity);
        newLine.GetComponent<ProceduralLine>().lineSpeed = levelSpeed;
        spawnedLines.Add(newLine);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, new Vector3(3, 1, 1));
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), new Vector3(1,1,1));
    }

    IEnumerator RepeatSpawning()
    {
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            SpawnNewLine();
            yield return new WaitForSeconds(continuousSpawnDelay);
        }
    }

    IEnumerator ChangeSpawning()
    {
        yield return new WaitForSeconds(initialSpawnDelay + levelDuration);

        while (true)
        {
            levelSpeed += additionalLevelSpeed;
            foreach (GameObject line in spawnedLines)
            {
                line.GetComponent<ProceduralLine>().lineSpeed = levelSpeed;
            }

            continuousSpawnDelay = Mathf.Clamp(continuousSpawnDelay - lessSpawnDelay, 0.5f, 10f);

            yield return new WaitForSeconds(levelDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnedLines.Count; i++)
        {
            GameObject tempLine = spawnedLines[i];
            if (tempLine == null)
            {
                spawnedLines.Remove(tempLine);
                //Debug.Log("Removed Line");
                //Debug.Log("In list now: " + spawnedLines.Count);
            }
            else
            {
                //tempLine.GetComponent<ProceduralLine>().lineSpeed += 100;
            }
        }

    }

}
