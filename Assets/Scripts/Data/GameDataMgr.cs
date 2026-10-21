using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    private UserData userData;
    public UserData UserData => userData;

    private List<string> userNames;
    public List<string> UserNames => userNames;

    public string lastUserName;

    private GameDataMgr()
    {
        userData = JsonMgr.Instance.LoadDate<UserData>(lastUserName);
    }

    public void SaveUserData(string userName)
    {
        JsonMgr.Instance.SaveDate(userData, userName);
        UserNames.Add(userName);
    }

    //记录上次登录账号
    public void savelastUserName(string userName)
    {
        lastUserName = userName;
    }

    //判断存不存在账号
    public bool IsExist(string userName)
    {
        if (UserNames.Contains(userName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
