/*
 * Author: Grace Foo
 * Date: 15/1/2024
 * Description: to help control the camera
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleCam()
    {
        ///this is to turn off the camera
        if (VuforiaBehaviour.Instance.enabled)
        {
            VuforiaBehaviour.Instance.VideoBackground.StopVideoBackgroundRendering();
            VuforiaBehaviour.Instance.enabled = false;
        }
        ///this is to turn on the camera
        else
        {
            VuforiaBehaviour.Instance.enabled = true;
            VuforiaBehaviour.Instance.VideoBackground.StartVideoBackgroundRendering();

        }
    }
}

