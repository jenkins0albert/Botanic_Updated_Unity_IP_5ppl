using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
using System.Xml.Linq;

public class ChangeMaze : MonoBehaviour
{

    //=================CHANGE MAZES=================
    public string bingoTag = "Bingo";
    public GameObject Maze1;
    public GameObject Maze2;
    public GameObject Maze3;
    public GameObject Maze1Trigger;
    public GameObject Maze2Trigger;
    public GameObject Maze3Trigger;
    //public GameObject UIStart; //Canvas for start button
    //public GameObject UIEnd; //Canvas for End canvas

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(bingoTag))
        {
            if (collision.gameObject == Maze1Trigger)
        {
            Maze1.SetActive(false);
            Maze2.SetActive(true);
            Maze3.SetActive(false);
        }
            else if(collision.gameObject == Maze2Trigger)
        {
            Maze1.SetActive(false);
            Maze2.SetActive(false);
            Maze3.SetActive(true);
        }
            else if (collision.gameObject == Maze3Trigger)
        {
            //Stop timer, send to FB
            StopCountdown();
            canvasPanelENDLose.SetActive(true); //Show Win UI !
            int score = Convert.ToInt32(TimerText.text); //Convert string of timer when stopped to INT

            //Firebase. Only item to insert is int Score
            //First/Fastest being the largest number(time remaining), Last/Slowest being the smallest number(time remaining)
            UpdateValueToFirebase(score);

        }
        }
        
    }


    

    //=============TIMER SCRIPT=========================
    public TextMeshProUGUI TimerText; //Display Time text
    public Button startButton; //Start timer countdown
    public Button restartButton;
    public float countdownTime = 100f; //Timer = x seconds
    private bool isCountingDown = false;
    public GameObject canvasPanelSTART; //Start version of UI
    public GameObject canvasPanelENDLose; // End (Lose)Version of UI
    public GameObject canvasPanelENDWin; // End (Win)Version of UI
    public GameObject Bingo1;
    public GameObject Bingo2;
    public GameObject Bingo3;

    public GameObject OGSPOT;

    public UpdateMazeScore UMSRef;
    
    void UpdateValueToFirebase(int score)
    {
        UMSRef.PlayerStatsUpdate("uuid", "username", score, score); 

    }

    public void StartCountdown() //Start timer
    {
        countdownTime = 100f; //reset timer time
        isCountingDown = true;
    }

    public void StopCountdown()// Stop timer
    {
        isCountingDown = false;
        

    }

    public void hideCanvas()
    {
        canvasPanelSTART.SetActive(false);
        
    }

    public void PlaceObjectAtPosition()
    {
        // Set the position of objectA to match the position of objectB
        Bingo1.transform.position = OGSPOT.transform.position;
        Bingo2.transform.position = OGSPOT.transform.position;
        Bingo3.transform.position = OGSPOT.transform.position;

    }


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartCountdown);//Start timer upon pressing start button
        startButton.onClick.AddListener(hideCanvas);//Hide Canvas and show Maze1 Only
        restartButton.onClick.AddListener(StartCountdown);//Start timer upon pressing start button
        restartButton.onClick.AddListener(hideCanvas);//Hide Canvas and show Maze1 Only

        //startButton.onClick.AddListener(PlaceObjectAtPosition);
        // restartButton.onClick.AddListener(PlaceObjectAtPosition);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            countdownTime -= Time.deltaTime; //Decrement of countdowntimer

            TimerText.text = Mathf.Round(countdownTime).ToString();//Update UI 

            if (countdownTime <= 0f) //if timer reaches 0, stop timer 
            {
                StopCountdown();
                canvasPanelENDLose.SetActive(true);
            }
        }
    }


}
