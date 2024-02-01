using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UIElements;

using Firebase.Database;
using Firebase.Extensions;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;

public class UpdateMazeScore : MonoBehaviour
{

    DatabaseReference dbPlayerStats; //Original firebase for user profiles "main database"
    DatabaseReference dbLeaderboard; 

    

    
    public void Awake()
    {
        dbPlayerStats = FirebaseDatabase.DefaultInstance.GetReference("playerstatsmaze");//Calls the parent?? 
        dbLeaderboard = FirebaseDatabase.DefaultInstance.GetReference("leaderboardmaze");

    }

    public void PlayerStatsUpdate(string uuid, string username, int score, int highscore)
    {
        Query playerQuery = dbPlayerStats.Child(uuid); //Make UUID appear and pair it with signed in user

        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            { // if error
                Debug.Log("task unable to comeplete");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot stats = task.Result; //Read values from firebase

                if (stats.Exists)
                {
                    MazeScore ms = JsonUtility.FromJson<MazeScore>(stats.GetRawJsonValue());




                    dbPlayerStats.Child(uuid).SetRawJsonValueAsync(ms.MazeScoreToJson()); //update if got existing
                                                                                          //dbLeaderboard.Child(uuid).SetRawJsonValueAsync(lb.LeaderboardToJson());

                    if (score > highscore)
                    {
                        UpdateLeaderboard(uuid, highscore);
                    }

                    else
                    {
                        ms = new MazeScore(username, score, highscore); //otherwise make new record
                        MazeScoreLeaderboard msl = new MazeScoreLeaderboard(username, highscore); //otherwise make new record

                        dbPlayerStats.Child(uuid).SetRawJsonValueAsync(ms.MazeScoreToJson());
                        dbLeaderboard.Child(uuid).SetRawJsonValueAsync(ms.MazeScoreToJson());
                        //Leaderboard lb = new Leaderboard(displayName, colonies);
                        //dbLeaderboard.Child(uuid).SetRawJsonValueAsync(lb.LeaderboardToJson());

                    }



                }
            }
        });
    }
        public void UpdateLeaderboard(string uuid, int highscore)
        {
            dbLeaderboard.Child(uuid).Child("highscore").SetValueAsync(highscore);
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
