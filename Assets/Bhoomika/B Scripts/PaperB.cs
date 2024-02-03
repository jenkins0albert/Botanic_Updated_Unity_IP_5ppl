/*
 * Author: Bhoomika Manot
 * Date: 28/1/2024
 * Description: Code for throwing the recycle items into the various bins. 
 */
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using UnityEngine.UI;

public class PaperB : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag, or use other criteria as needed
        if (collision.gameObject.CompareTag("Paper"))
        {
            Destroy(collision.gameObject); // Destroy the collided object
            Debug.Log("Destroyed on collision");
        }
        else
        {
            Debug.Log("Wrong, paper should be here");
        }
    }
}
