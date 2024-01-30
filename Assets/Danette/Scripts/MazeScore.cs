using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScore
{
    public string username;
    public int timeleft;

    // Start is called before the first frame update
    public MazeScore()
    {
    }

    public MazeScore(string username, int timeleft)
    {
        this.username = username;
        this.timeleft = timeleft;
        

    }

    public string MazeScoreToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
