using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Maze1"))
        {
            Maze1.SetActive(false);
            Maze2.SetActive(true);
            Maze3.SetActive(false);
        }
        else if(other.CompareTag("Maze2"))
        {
            Maze1.SetActive(false);
            Maze2.SetActive(false);
            Maze3.SetActive(true);
        }
        else if (other.CompareTag("Maze3"))
        {
            //Stop timer, send to FB
            StopCountdown();
            canvasPanelENDWin.SetActive(true);
        }
    }


    

    //=============TIMER SCRIPT=========================
    public TextMeshProUGUI TimerText; //Display Time text
    public Button startButton; //Start timer countdown
    public float countdownTime = 60f; //Timer = 60 seconds
    private bool isCountingDown = false;
    public GameObject canvasPanelSTART; //Start version of UI
    public GameObject canvasPanelENDLose; // End (Lose)Version of UI
    public GameObject canvasPanelENDWin; // End (Win)Version of UI



    public void StartCountdown() //Start timer
    {
        countdownTime = 60f; //reset timer time
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


// Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartCountdown);//Start timer upon pressing start button
        startButton.onClick.AddListener(hideCanvas);//Hide Canvas and show Maze1 Only
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
