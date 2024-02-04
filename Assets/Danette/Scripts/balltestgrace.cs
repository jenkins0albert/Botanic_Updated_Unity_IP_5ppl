using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balltestgrace : MonoBehaviour
{
    //HEY IF UR READING THIS DONT USE THIS CODE ITS BAD 
    public float tiltSpeed = 100f;
    public float ballSpeed = 6f;
    public List<Rigidbody> ballsRigidbodies = new List<Rigidbody>();

    void Start()
    {
 

        // Ensure that at least one ball's Rigidbody is assigned
        if (ballsRigidbodies.Count == 0)
        {
            Debug.LogError("No ball Rigidbodies assigned. Attach the Rigidbodies of the balls to the script in the Unity Editor.");
        }
    }

    void Update()
    {
        Debug.Log("Update method is running.");

        float tiltX = Input.acceleration.x * tiltSpeed;
        float tiltZ = Input.acceleration.z * tiltSpeed;

        // Rotate the maze
        transform.Rotate(0f, tiltX, tiltZ);

        // Apply force to each ball
        foreach (var ballRigidbody in ballsRigidbodies)
        {
            if (ballRigidbody != null)
            {
                // Apply force to move the ball forward
                Vector3 movement = new Vector3(tiltX, 0f, tiltZ);
                ballRigidbody.AddForce(movement * ballSpeed, ForceMode.Acceleration);
            }
        }
    }
}