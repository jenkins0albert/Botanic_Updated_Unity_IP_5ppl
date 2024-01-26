using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class User
{

    
    public string username;
    public string displayname;
    public string email;
    public bool active;

    public long lastactive;
    public long createdon;
    public long updatedon;
    
    public User()
    {
    }

    public User(string username, string displayname, string email, bool active = true)
    {
        this.username = username;
        this.displayname = displayname;
        this.email = email;
        this.active = active; 

        var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        this.lastactive = timestamp;
        this.createdon = timestamp;
        this.updatedon = timestamp;
     
    }

    public string UserToJson()
    { 
        return JsonUtility.ToJson(this);
    }
        
    
    
}
