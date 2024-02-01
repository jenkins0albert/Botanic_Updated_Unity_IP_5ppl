/*
 * Author: Bhoomika Manot
 * Date: 22/1/2024
 * Description: Code for picking up the recyling items
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    //Declare variables
    public GameObject recycleSpawn;
    public BoxCollider spawnArea;
    public int maxObjectsToSpawn = 10;
    private bool hasSpawned = false;
    //public int countObjs = 0;

    //UI
    public TextMeshProUGUI timerText;

    void Start()
    {
        //Start timer text
        timerText.text = "Time: 10s";
    }

    public void StartSpawning()
    {
        //If bool is false, starts coroutine
        if (!hasSpawned)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        //To allow spawning only once
        hasSpawned = true;

        //Checks for time
        float totalTime = 10f;
        float elapsedTime = 0f;

        //Checks for number of objects spawned
        int spawnedObjectCount = 0;

        while (elapsedTime < totalTime)
        {
            //Generate a random position within the empty Box Collider
            Vector3 randomPosition = GetRandomPositionInCollider(spawnArea);

            //Checks if all objets are spawned, if not instantiate
            if (spawnedObjectCount < maxObjectsToSpawn)
            {
                //Instantiate the object at the random position
                Instantiate(recycleSpawn, randomPosition, Quaternion.identity);
                spawnedObjectCount++;
            }
           
            //Random waiting time before respawning
            float waitTime = Random.Range(0.2f, 1.0f);
            yield return new WaitForSeconds(waitTime);

            //Adds time & spawned objects count
            elapsedTime += waitTime;
            
            //Update the timer text
            float remainingTime = Mathf.Max(0f, totalTime - elapsedTime);
            timerText.text = "Time: " + Mathf.Round(remainingTime) + "s";           
        }
        //hasSpawned = false;
    }

    Vector3 GetRandomPositionInCollider(BoxCollider collider)
    {
        //Calculate a random position within the collider
        float x = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        float z = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(x, y, z);
    }

    public void TestTap()
    {
        //countObjs++;

        Debug.Log("TestTap WORKING");

        //recycleSpawn.gameObject.SetActive(false);
        
    }
}


