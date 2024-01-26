using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private bool isThrown = false;
    public bool inBox = false;
    public int count = 0;

    void Update()
    {
        if (isThrown && GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
        {
            // Check if the ball has stopped moving, e.g., landed
            CheckIfLandedInBox();
        }
    }

    void CheckIfLandedInBox()
    {
        // Implement logic to check if the ball is in the box
        // You can use collider checks, coordinates, or any other method
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            inBox = true;
            count += 1;
            Debug.Log("Ball script is count");
            Debug.Log(count);
        }
    }

    public void Throw(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        isThrown = true;
    }
}
