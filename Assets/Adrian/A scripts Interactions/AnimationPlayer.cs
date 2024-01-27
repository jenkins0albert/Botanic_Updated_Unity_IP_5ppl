using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buildui;

    public GameObject decorateui;
    public bool opencheck = false;
    public bool opencheckdec = false;

    public void OpenUI()
    {
        if (opencheck == false) 
        {
            
            buildui.GetComponent<Animator>().Play("scrollbar_appear");
            opencheck = true;
        }
    }

    public void CloseUI()
    {
        if (opencheck == true)
        {

            buildui.GetComponent<Animator>().Play("scrollbar_disappear");
            opencheck = false;
        }
    }

    public void OpenDecUI()
    {
        if (opencheckdec == false)
        {

            decorateui.GetComponent<Animator>().Play("scrollbar_appear");
            opencheckdec = true;
        }

        else
        {
            decorateui.GetComponent<Animator>().Play("scrollbar_disappear");
            opencheckdec = false;
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
