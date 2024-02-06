using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAnim : MonoBehaviour
{   
    public Animator cloudsAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayAnim()
    {   

        cloudsAnim.Play("CloudsAnim");
    }

}
