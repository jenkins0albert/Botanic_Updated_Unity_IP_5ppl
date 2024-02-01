using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    //Declare variables
    public GameObject[] ballPrefabs;
    public Transform throwPoint;
    public float minThrowForce = 0.1f;
    public float maxThrowForce = 5f;

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
        
    }

    public void InstantiateBall(/*VirtualButtonBehaviour vb*/)
    {
        //Get a random index from the ballPrefabs array
        int randomIndex = UnityEngine.Random.Range(0, ballPrefabs.Length);

        //Instantiate a new projectile at the throw point with the randomly selected prefab
        GameObject projectile = Instantiate(ballPrefabs[randomIndex], throwPoint.position, Quaternion.identity);

        //Call ThrowForce function
        if (LeanTouch.Fingers.Count > 0 && LeanTouch.Fingers[0].Up)
        {
            CalculateThrowForce(LeanTouch.Fingers[0]);
            //To ensure function is carried out
            Debug.Log("Touch input ok");
        }

        //To ensure function is carried out
        Debug.Log("Instantiated ball func working");
    }

    void CalculateThrowForce(LeanFinger finger)
    {
        // Calculate the throw direction based on the AR camera's forward direction
        Vector3 throwDirection = Camera.main.transform.forward;

        // Calculate the throw force based on the finger's swipe delta position
        float swipeDeltaMagnitude = finger.SwipeScreenDelta.magnitude;
        float normalizedDeltaMagnitude = Mathf.Clamp01(swipeDeltaMagnitude / Screen.width);
        float calculatedThrowForce = Mathf.Lerp(minThrowForce, maxThrowForce, normalizedDeltaMagnitude);

        // Instantiate a new projectile at the throw point with a randomly selected prefab
        int randomIndex = UnityEngine.Random.Range(0, ballPrefabs.Length);
        GameObject projectile = Instantiate(ballPrefabs[randomIndex], throwPoint.position, Quaternion.identity);

        // Apply force to the projectile based on the calculated throw direction and force
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(throwDirection * calculatedThrowForce, ForceMode.Impulse);

        // Debug the calculated throw force
        Debug.Log("Calculated Throw Force: " + calculatedThrowForce);
    }

    /*public void ShootBall(GameObject projectile)
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
        rb.AddForce(transform.forward * 0.1f, ForceMode.Impulse);

        //To ensure function is carried out
        Debug.Log("Shoot Ball func working");

    }*/
}
