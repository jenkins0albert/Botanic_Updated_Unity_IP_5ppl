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
    public GameObject[] recycleSpawn;
    public int maxObjectsToSpawn = 7;
    private bool hasSpawned = false;
    //public int countObjs = 0;

    //Spawning area size
    public Vector3 spawnSize = new Vector3(0.1f, 0.123819f, 1f);

    //UI
    public TextMeshProUGUI timerText;
    public GameObject startPage;
    public GameObject endPage;
    public GameObject timePage;

    void Start()
    {
        //Start timer text
        timerText.text = "Time: 10s";
    }

    void SetActiveObj()
    {
        foreach (GameObject obj in recycleSpawn)
        {
            obj.SetActive(true);
        }
    }

    public void StartSpawning()
    {
        //To hide UI
        startPage.gameObject.SetActive(false);

        //If bool is false, starts coroutine
        if (!hasSpawned)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        //Set active prefabs
        SetActiveObj();

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
            Vector3 randomPosition = GetRandomPosition(spawnSize);

            //Checks if all objets are spawned, if not instantiate
            if (spawnedObjectCount < maxObjectsToSpawn)
            {
                int randomIndex = UnityEngine.Random.Range(0, recycleSpawn.Length);

                //Instantiate the object at the random position
                GameObject items = Instantiate(recycleSpawn[randomIndex], randomPosition, Quaternion.identity, transform);
                spawnedObjectCount++;
            }
           
            //Random waiting time before respawning
            float waitTime = Random.Range(0.2f, 1.0f);
            yield return new WaitForSeconds(waitTime);

            //TestTap();

            //Adds time & spawned objects count
            elapsedTime += waitTime;
            
            //Update the timer text
            float remainingTime = Mathf.Max(0f, totalTime - elapsedTime);
            timerText.text = "Time: " + Mathf.Round(remainingTime) + "s";
            
        }

        // Check if the timer is zero and set the game object active
        if (elapsedTime >= totalTime)
        {
            endPage.gameObject.SetActive(true);
            timePage.gameObject.SetActive(false);

        }

        //hasSpawned = false;
    }

    Vector3 GetRandomPosition(Vector3 size)
    {
        // Calculate a random position within the specified size in meters
        float x = Random.Range(transform.position.x - size.x / 2f, transform.position.x + size.x / 2f);
        float y = Random.Range(transform.position.y - size.y / 2f, transform.position.y + size.y / 2f);
        float z = Random.Range(transform.position.z - size.z / 2f, transform.position.z + size.z / 2f);

        return new Vector3(x, y, z);
    }

    public void TestTap(GameObject tappedObject)
    {
        //countObjs++;

        Debug.Log("TestTap WORKING: "+ tappedObject.name);

        tappedObject.gameObject.SetActive(false);
        
    }

    /*public void Debugging()
    {
        Debug.Log(countObjs);
    }*/
}


