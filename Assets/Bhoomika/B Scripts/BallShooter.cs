/*
 * Author: Bhoomika Manot
 * Date: 18/1/2024
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

public class BallShooter : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public Transform throwPoint;
    public float minThrowForce = 0.1f;
    public float maxThrowForce = 5f;
    private GameObject projectile;

    public GameObject timerPanel;
    public TextMeshProUGUI timerText;
    public GameObject end;

    private float timerDuration = 20f;
    private float currentTime;
    private bool timerStarted = false;

    void Start()
    {
        Debug.Log("Ball Mngr script working");
    }

    void Update()
    {
        UpdateTimerText();
    }

    public void InstantiateBall()
    {
        if (!timerStarted) // Check if the timer hasn't started yet
        {
            StartCoroutine(StartTimer());
            timerStarted = true; // Set the flag to indicate that the timer has started
        }

        if (currentTime > 0)
        {
            timerPanel.gameObject.SetActive(true);

            int randomIndex = UnityEngine.Random.Range(0, ballPrefabs.Length);
            projectile = Instantiate(ballPrefabs[randomIndex], throwPoint.position, Quaternion.identity);

            if (Lean.Touch.LeanTouch.Fingers.Count > 0 && Lean.Touch.LeanTouch.Fingers[0].Up)
            {
                CalculateThrowForce(Lean.Touch.LeanTouch.Fingers[0]);
                Debug.Log("Touch input ok");
            }

            Debug.Log("Instantiated ball func working");
        }
        else
        {
            Debug.Log("Timer expired. Cannot instantiate more balls.");
            timerPanel.gameObject.SetActive(false);
        }
    }

    private void CalculateThrowForce(Lean.Touch.LeanFinger finger)
    {
        Vector3 throwDirection = Camera.main.transform.forward;
        float swipeDeltaMagnitude = finger.SwipeScreenDelta.magnitude;
        float normalizedDeltaMagnitude = Mathf.Clamp01(swipeDeltaMagnitude / Screen.width);
        float calculatedThrowForce = Mathf.Lerp(minThrowForce, maxThrowForce, normalizedDeltaMagnitude);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(throwDirection * calculatedThrowForce, ForceMode.Impulse);

        Debug.Log("Calculated Throw Force: " + calculatedThrowForce);
    }

    IEnumerator StartTimer()
    {
        currentTime = timerDuration; // Reset the timer duration
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerText();
        }

        //Set Active Panel
        //end.gameObject.SetActive(true);
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + currentTime.ToString("F0");
    }
}
