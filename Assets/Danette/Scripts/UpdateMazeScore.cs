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

    DatabaseReference dbPlayerStats;
    DatabaseReference dbLeaderboard;

    
    public void Awake()
    {
        dbPlayerStats = FirebaseDatabase.DefaultInstance.GetReference("playerstatsmaze");
        dbLeaderboard = FirebaseDatabase.DefaultInstance.GetReference("leaderboardmaze");

    }

    public void PlayerStatsUpdate(string uuid, string username, int score)
    {
        Query playerQuery = dbPlayerStats.Child(uuid);

        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.Log("task unable to comeplete");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot stats = task.Result;

                if (stats.Exists)
                {
                    MazeScore ms = JsonUtility.FromJson<MazeScore>(stats.GetRawJsonValue());
                   

                   

                    dbPlayerStats.Child(uuid).SetRawJsonValueAsync(ms.MazeScoreToJson());
                   //dbLeaderboard.Child(uuid).SetRawJsonValueAsync(lb.LeaderboardToJson());
                }

                else
                {
                    MazeScore ms = new MazeScore(username, score);
                    dbPlayerStats.Child(uuid).SetRawJsonValueAsync(ms.MazeScoreToJson());

                    //Leaderboard lb = new Leaderboard(displayName, colonies);
                    //dbLeaderboard.Child(uuid).SetRawJsonValueAsync(lb.LeaderboardToJson());

                }



            }
        });
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
