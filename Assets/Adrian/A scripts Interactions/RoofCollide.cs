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

    public GameObject cancelbtn;
    public AnimationPlayer uianim;

    public TapInteractions tap;

    public ParticleSystem buildeffectroof;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "roofdrag")
        {
            greyedoutroof.SetActive(false);
            roof.SetActive(true);
            roofgroundplane.SetActive(false);
            buildsound.Play();
            Debug.Log("roof");
            buildeffectroof.Play();
            cancelbtn.SetActive(false);
            uianim.OpenUI();
            tap.count += 1;

        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
