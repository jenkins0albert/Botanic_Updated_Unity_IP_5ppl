using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScore
{
    public string username;
    public int timeleft;
    public int timelefthigh;

    // Start is called before the first frame update
    public MazeScore()
    {
    }

    public MazeScore(string username, int timeleft, int timelefthigh)
    {
        this.username = username;
        this.timeleft = timeleft;
        this.timelefthigh = timelefthigh;
    }

    public string MazeScoreToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
