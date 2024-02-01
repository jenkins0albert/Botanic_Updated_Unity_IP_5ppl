using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScoreLeaderboard


{

    public string username;
    
    public int highscore;

    public MazeScoreLeaderboard()
    {
    }

    public MazeScoreLeaderboard(string username, int highscore)
    {
        this.username = username;
        
        this.highscore = highscore;
    }

    public string MazeScoreLeaderboardToJson()
    {
        return JsonUtility.ToJson(this);
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
