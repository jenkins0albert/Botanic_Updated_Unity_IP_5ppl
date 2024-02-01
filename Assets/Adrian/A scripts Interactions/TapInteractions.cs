using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class TapInteractions : MonoBehaviour
{
    public int count = 0;

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject buildthing;
    public ParticleSystem build;

    public GameObject fence;
    public GameObject roof;
    public GameObject floor;

    public GameObject Streamer;
    public bool streamerbool = false;
    public GameObject Flowers;
    public bool flowersbool = false;
    public GameObject Rocks;
    public bool rocksbool = false;

    public GameObject taptext;

    public void MakeStreamer()
    {
        if (streamerbool == false)
        {
            Streamer.SetActive(true);
            streamerbool = true;
        }
        else
        {
            Streamer.SetActive(false);
            streamerbool = false;
        }
    }
    public void MakeFlower()
    {
        if (flowersbool == false)
        {
            Flowers.SetActive(true);
            flowersbool = true;
        }
        else
        {
            Flowers.SetActive(false);
            flowersbool = false;
        }
    }
    public void MakeRocks()
    {
        if (rocksbool == false)
        {
            Rocks.SetActive(true);
            rocksbool = true;
        }
        else
        {
            Rocks.SetActive(false);
            rocksbool = false;
        }
    }

    public void FinishBuild()
    {
        if (count == 3)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            buildthing.SetActive(false);
            Debug.Log("asdbad");

        }

    }
    public void ResetBuild()
    {
        transform.localPosition = new Vector3(0, 0, 0);

        fence.transform.localPosition = new Vector3(0, 0, 0);
        roof.transform.localPosition = new Vector3(0, 0, 0);
        floor.transform.localPosition = new Vector3(0, 0, 0);
    }



    public void buildeffect()
    {
        build.Play();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            //set ui active;
            taptext.SetActive(true);
            Debug.Log("asdbad");
        }
    }
}
