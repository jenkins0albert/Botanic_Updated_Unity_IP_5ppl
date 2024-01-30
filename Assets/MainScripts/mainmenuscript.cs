using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuscript : MonoBehaviour
{
    public string Url;

    /// <summary>
    /// opens a link to the website 
    /// </summary>
    public void Openthewebsite()
    {
        Application.OpenURL(Url);
    }
    /// <summary>
    /// to quit the game
    /// </summary>
    public void doExitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
