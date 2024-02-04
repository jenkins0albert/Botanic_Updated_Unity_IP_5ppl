using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTilt : MonoBehaviour
{
    public float tiltSpeed = 100f;
    void Update()
    {
        float tiltX = Input.acceleration.x;
        float tiltZ = Input.acceleration.z;

        // Move the player based on tilt
        Vector3 movement = new Vector3(tiltX, 0f, tiltZ);
        transform.Translate(movement * tiltSpeed * Time.deltaTime);
    }
}
