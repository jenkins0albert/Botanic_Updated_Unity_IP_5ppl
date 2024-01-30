using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using Unity.UI;

public class BallShooter : MonoBehaviour
{
    //Declare variables
    public GameObject[] ballPrefabs;
    public Transform throwPoint;
    public float throwForce = 0.1f;

    public VirtualButtonBehaviour vB;

    void Start()
    {
        //To ensure script is working
        Debug.Log("Ball Mngr script working");

        //Virtual Button OnClick()
        //vB.RegisterOnButtonPressed(InstantiateBall);
    }

    void Update()
    {
        /*
        //Check for touch input
        if (LeanTouch.Fingers.Count > 0 && LeanTouch.Fingers[0].Up)
        {
            //To ensure function is carried out
            Debug.Log("Touch input ok");
        }
        */
    }

    public void InstantiateBall(/*VirtualButtonBehaviour vb*/)
    {
        //Get a random index from the ballPrefabs array
        int randomIndex = UnityEngine.Random.Range(0, ballPrefabs.Length);

        //Instantiate a new projectile at the throw point with the randomly selected prefab
        GameObject projectile = Instantiate(ballPrefabs[randomIndex], throwPoint.position, Quaternion.identity);

        //Call ShootBall function
        ShootBall(projectile);

        //To ensure function is carried out
        Debug.Log("Instantiated ball func working");
    }

    public void ShootBall(GameObject projectile)
    {

        //Calculate the throw direction based on the AR camera's forward direction
        Vector3 throwDirection = Camera.main.transform.forward;

        //Apply force to the basketball based on the calculated throw direction
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        //Testing shooting
        /*GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        // Apply a force to shoot the ball
        rb.AddForce(transform.forward * 0.1f, ForceMode.Impulse);*/

        //To ensure function is carried out
        Debug.Log("Shoot Ball func working");

    }
}
