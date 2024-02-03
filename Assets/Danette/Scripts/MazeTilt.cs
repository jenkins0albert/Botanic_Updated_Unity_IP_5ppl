using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTilt : MonoBehaviour
{
    public float tiltSpeed = 100f;
    void Update()
    {
        float tiltX = Input.acceleration.x * tiltSpeed;
        float tiltZ = Input.acceleration.z * tiltSpeed;

        transform.Rotate(tiltX, 0f, tiltZ);
    }
}
