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

    public ParticleSystem buildeffectfence;

    public GameObject cancelbtn;
    public AnimationPlayer uianim;


    public TapInteractions tap;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "fencedrag")
        {
            greyedoutfence.SetActive(false);
            fence.SetActive(true);
            fencegroundplane.SetActive(false);
            buildsound.Play();
            buildeffectfence.Play();
            cancelbtn.SetActive(false);
            uianim.OpenUI();
            Debug.Log("fence");

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
