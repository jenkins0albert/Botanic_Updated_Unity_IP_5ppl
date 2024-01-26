/*
 * Author: Grace Foo
 * Date: 16/1/2024
 * Description: Code for game manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gamecount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamecount == 4)
        {

        }
    }

    public void increaseCount()
    {
        gamecount = gamecount + 1;
    }

    public void openGreenhouse()
    {
        //set active old one
        //set active new one
    }
}
