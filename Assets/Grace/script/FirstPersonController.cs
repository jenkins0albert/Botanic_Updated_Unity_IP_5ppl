using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject mainCamera;

    public float rotationSpeed = 0.5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (mainCamera != null)
            {
                // Check if touch is on the left or right half of the screen
                bool touchOnLeftHalf = touch.position.x < Screen.width / 2;

                if (touchOnLeftHalf)
                {
                    // Rotate the camera based on touch delta on the left side
                    mainCamera.transform.Rotate(Vector3.left, touch.deltaPosition.y * rotationSpeed);
                }
                else
                {
                    // Move the player based on touch delta on the right side
                    Vector3 moveDirection = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y).normalized;
                    moveDirection = mainCamera.transform.TransformDirection(moveDirection);
                    moveDirection.y = 0;
                    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                    //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                }
            }
            else
            {
                Debug.LogError("Main camera is not assigned in the Unity Editor.");
            }
        }
    }
}

    

