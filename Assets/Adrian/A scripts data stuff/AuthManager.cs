using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UIElements;

using Firebase.Database;
using Firebase.Extensions;


public class AuthManager : MonoBehaviour
{
    FirebaseAuth auth;

    

    public TMP_InputField EmailField;

    public TMP_InputField UsernameField;

    public TMP_InputField passwordField;


    public TMP_InputField EmailFieldLogin;
    public TMP_InputField PasswordFieldLogin;

    public DatabaseReference mDatabaseRef;



    public GameObject createAccBtn;

    public GameObject loginpage;
    
    public void SignUp()
    {

        
        string email = EmailField.text.Trim();
        string username = UsernameField.text.Trim();
        string password = passwordField.text.Trim();

       


        SignUpUser(email,username, password);

        
        
           


    }

    public void SignIn()
    {


        string email = EmailFieldLogin.text.Trim();
       
        string password = PasswordFieldLogin.text.Trim();




        SignInUser(email, password);






    }

    

    public void SignUpUser(string email,string username, string password)
    
    {
        //automatically pass user info to the firebase project
        //attempt to create new user or check with there's already one
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            //perform task handling
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Sorry, there was an error creating your new account, ERROR: " + task.Exception);
                Debug.Log("error");
                return;//exit from the attempt
            }
            else if (task.IsCompleted)
            {

                Debug.Log("success");

                Firebase.Auth.AuthResult newPlayer = task.Result;
                Debug.LogFormat("Welcome to Ant Farm Simulator {0}", newPlayer.User.UserId);
                CreateNewUser(newPlayer.User.UserId, username, username, email);

                
                //do anything you want after player creation eg. create new player

            }
        });

    }

    public void CreateNewUser(string uuid, string displayname, string username, string email)
    {
        User newUser = new User(displayname, username, email);
        mDatabaseRef.Child("players/").Child("uuid/" + uuid).SetRawJsonValueAsync(newUser.UserToJson());

        UpdateDisplayName(displayname);
    }
    public void SignInUser(string email, string password)
    { 
       

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            //perform task handling
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Sorry, there was an error creating your new account, ERROR: " + task.Exception);
                Debug.Log("error");

            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.AuthResult newPlayer = task.Result;
                Debug.LogFormat("Welcome to Ant Farm Simulator {0}", newPlayer.User.UserId);

                Debug.Log("signed in");
                

                //do anything you want after player creation eg. create new player

            }
        });
    }


    public void UpdateDisplayName(string displayname) 
    {
        if (auth.CurrentUser != null)
        {
            UserProfile profile = new UserProfile { DisplayName = displayname };
            auth.CurrentUser.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    Debug.Log("asdasda");
                    return;
                }
                Debug.Log("Welcome "+auth.CurrentUser.UserId);
                
            });
        }
    }


    public string GetCurrentUserDisplayName()
    { 
        return auth.CurrentUser.DisplayName;
    }

    public string GetCurrentUser()
    {
        return auth.CurrentUser.UserId;
    }
    public void SignOutUser()
    {
        Debug.Log("sign out");
        if (auth.CurrentUser != null)
        {
            auth.SignOut();

            loginpage.SetActive(true);
            

        }

        
        
    }
    // Start is called before the first frame update
    void Awake()
    {

        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        DontDestroyOnLoad(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
