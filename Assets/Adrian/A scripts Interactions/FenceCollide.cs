using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject greyedoutfence;
    public GameObject fence;
    public GameObject fencegroundplane;
    public AudioSource buildsound;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "fencedrag")
        {
            greyedoutfence.SetActive(false);
            fence.SetActive(true);
            fencegroundplane.SetActive(false);
            buildsound.Play();
        }
    }
    void Start()
    {
        buildsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
