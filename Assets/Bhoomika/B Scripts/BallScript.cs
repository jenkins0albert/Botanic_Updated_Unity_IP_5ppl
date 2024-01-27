using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using Lean.Touch;

public class BallScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Ball script is working");
    }

    private void OnCollisonEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Destroy(collision.gameObject);
            Debug.Log("Drag is working");
        }
    }


    /*public GameObject basketballPrefab;
    public Transform throwPoint;
    public float throwForce = 10f;

    public void ThrowBasketball()
    {
        // Instantiate a new basketball at the throw point
        GameObject basketball = Instantiate(basketballPrefab, throwPoint.position, Quaternion.identity);

        // Calculate the throw direction based on the AR camera's forward direction
        Vector3 throwDirection = Camera.main.transform.forward;

        // Apply force to the basketball based on the calculated throw direction
        Rigidbody rb = basketball.GetComponent<Rigidbody>();
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }*/

}

    
