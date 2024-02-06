using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    [SerializeField] AudioSource BGM;

    public void OnMusic()
    {
        BGM.Play();
    }

    public void OffMusic()
    {
        BGM.Stop();
    }
}
