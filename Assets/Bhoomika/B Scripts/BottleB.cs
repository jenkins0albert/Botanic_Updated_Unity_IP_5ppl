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

public class BottleB : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has a specific tag, or use other criteria as needed
        if (other.CompareTag("Bottle"))
        {
            Destroy(other.gameObject); // Destroy the triggered object
            Debug.Log("Destroyed on trigger");
        }
        else
        {
            Destroy(other.gameObject); // Destroy the triggered object
            Debug.Log("Wrong, bottle should be here");
        }
    }
}
