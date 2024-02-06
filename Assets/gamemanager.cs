/*
 * Author: Grace Foo
 * Date: 16/1/2024
 * Description: Code for game manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gamecount = 0;
    public GameObject GreenhouseNotif;
    public AudioSource GreenhouseNotifSound;
    public GameObject Greenhouseclose;
    public GameObject Greenhouse;

    public TextMeshProUGUI increaseText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///if it counts that the player has visited all 4 areas, this function which is basically notification will be called
        if(gamecount == 4)
        {
            openGreenhouse();
        }
    }
    /// <summary>
    /// increases the count and changes the text on how many areas there are left to visit
    /// </summary>
    public void increaseCount()
    {
        gamecount = gamecount + 1;
        increaseText.text = "areas left: " + (4 - gamecount);
    }
    /// <summary>
    /// sets true all the notification and the accessable greenhouse
    /// </summary>
    public void openGreenhouse()
    {
        Debug.Log("open");
        GreenhouseNotifSound.Play();
        GreenhouseNotif.SetActive(true);
        Greenhouse.SetActive(true);
        Greenhouseclose.SetActive(false);
    }
    public void debugtest()
    {
        Debug.Log("testing");
    }
}
