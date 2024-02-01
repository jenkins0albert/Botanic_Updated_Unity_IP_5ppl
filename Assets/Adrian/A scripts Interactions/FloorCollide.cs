using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject greyedoutfloor;
    public GameObject floor;
    public GameObject floorgroundplane;
    public AudioSource buildsound;

    public ParticleSystem buildeffectfloor;

    public GameObject cancelbtn;
    public AnimationPlayer uianim;

    public TapInteractions tap;

   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "floordrag")
        {
            greyedoutfloor.SetActive(false);
            floor.SetActive(true);
            floorgroundplane.SetActive(false);
            buildsound.Play();
            buildeffectfloor.Play();
            cancelbtn.SetActive(false);
            uianim.OpenUI();
            Debug.Log("floor");

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
