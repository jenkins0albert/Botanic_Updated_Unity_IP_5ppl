using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoData
{

    public string photoname;
   
    public long createdon;
    

    public PhotoData()
    {
    }

    public PhotoData(string photoname)
    {
        this.photoname = photoname;
        

        var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        
        this.createdon = timestamp;
        

    }

    public string PhotoToJson()
    {
        return JsonUtility.ToJson(this);
    }



}
