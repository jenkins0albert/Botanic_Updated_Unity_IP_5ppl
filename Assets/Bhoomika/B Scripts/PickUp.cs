using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject objectToSpawn;
    public BoxCollider spawnArea;
    public int numberOfObjectsToSpawn = 10;

    void Start()
    {
        
        Debug.Log("Started");
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Generate a random position within the Box Collider bounds
            Vector3 randomPosition = GetRandomPositionInCollider(spawnArea);

            // Instantiate the object at the random position
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            Debug.Log("Spawned");
        }
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

