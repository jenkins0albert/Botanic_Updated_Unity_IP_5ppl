using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class BallGameManager : MonoBehaviour
{
    public BallScript ball;
    public Vector3 throwForce = new Vector3(0, 5, 10);

    void OnEnable()
    {
        LeanTouch.OnFingerUp += OnFingerUp;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerUp -= OnFingerUp;
    }

    void OnFingerUp(LeanFinger finger)
    {
        // Check if the finger released over the ball
        if (finger.IsOverGui && finger.StartedOverGui)
        {
            ball.Throw(throwForce);
        }
    }
}
