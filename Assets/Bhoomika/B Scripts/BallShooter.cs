using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Lean.Touch;
using TMPro;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    //Declare variables
    public GameObject ballPrefab;
    public VirtualButtonBehaviour vB;

    void Start()
    {
        //To ensure script is working
        Debug.Log("Ball Mngr script working");

        //Virtual Button OnClick()
        vB.RegisterOnButtonPressed(ShootBall);
    }

    public void ShootBall(VirtualButtonBehaviour vb)
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Apply a force to shoot the ball
        rb.AddForce(transform.forward * 4f, ForceMode.Impulse);

        //To ensure function is carried out
        Debug.Log("Shoot Ball func working");

        //ballPrefab.gameObject.SetActive(false);
    }
}
