using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject greyedoutroof;
    public GameObject roof;
    public GameObject roofgroundplane;
    public AudioSource buildsound;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "roofdrag")
        {
            greyedoutroof.SetActive(false);
            roof.SetActive(true);
            roofgroundplane.SetActive(false);
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
