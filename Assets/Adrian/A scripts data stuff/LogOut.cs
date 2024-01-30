using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UIElements;

using Firebase.Database;
using Firebase.Extensions;

public class LogOut : MonoBehaviour
{
    FirebaseAuth auth;
    

    public void SignOutUser()
    {

        if (auth.CurrentUser != null)
        {
            auth.SignOut();
            Debug.Log("sign out");


            nextSceneAnimation.FadeToMenu();

        }

        else
        {
            Debug.Log("no user");
        }



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
