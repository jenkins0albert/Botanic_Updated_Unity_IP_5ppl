using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using Unity.UI;

public class PickUp : MonoBehaviour
{
    public GameObject objectToSpawn;
    public BoxCollider spawnArea;
    public int numberOfObjectsToSpawn = 10;

    private bool isSpawning = false;

    public TextMeshProUGUI timerText;

    void Start()
    {
        //
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        isSpawning = true;
        float totalTime = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            // Generate a random position within the Box Collider bounds
            Vector3 randomPosition = GetRandomPositionInCollider(spawnArea);

            // Instantiate the object at the random position
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            // Wait for a random time before spawning the next object
            float waitTime = Random.Range(0.1f, 1.0f);
            yield return new WaitForSeconds(waitTime);

            elapsedTime += waitTime;
        }

        isSpawning = false;
    }

    Vector3 GetRandomPositionInCollider(BoxCollider collider)
    {
        // Calculate a random position within the collider bounds
        float x = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        float z = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(x, y, z);
    }
}


