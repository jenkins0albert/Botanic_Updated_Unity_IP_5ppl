/*
 * Author: Grace Foo
 * Date: 31/1/2024
 * Description: Code for walking player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 0.28f;
    /// <summary>
    /// this is the players camera
    /// </summary>
    public GameObject mainCamera;

    public float rotationSpeed = 0.1f;

    void Update()
    {
        ///if they feel any touch it will go under here
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            ///to check if the camera is connected properly
            if (mainCamera != null)
            {
                // Check if touch is on the left or right half of the screen
                bool touchOnLeftHalf = touch.position.x < Screen.width / 2;

                if (touchOnLeftHalf)
                {
                    // calculates the roation from the touch of the position
                    float rotationY = touch.deltaPosition.x * rotationSpeed;
                    //rotates the camera according to the float rotation y
                    mainCamera.transform.Rotate(0, rotationY, 0);
                }
                else
                {
                    /// Move the player based on touching the right side
                    Vector3 moveDirection = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);
                    /// Convert the movement direction based on the camera's orientation
                    moveDirection = mainCamera.transform.TransformDirection(moveDirection);
                    ///player at same height and does not do any funny tilting or moving
                    moveDirection.y = 0;
                    ///move player accordingly to the moveDirection
                    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                }
            }

        }
    }
}

    

