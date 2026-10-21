using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    private UserData userData;
    public UserData UserData => userData;

    private AccountIndex accountIndex;
    public string lastUser => accountIndex.lastUserName;

    

    private GameDataMgr()
    {
        accountIndex = JsonMgr.Instance.LoadDate<AccountIndex>("accounts");

        userData = LoadUserName(lastUser);
    }

    //判断用户是否存在
    public bool IsExist(string username)
    {
        return accountIndex.userNames.Contains(username);
    }

    //存储
    public void SaveUserData(UserData data, string username)
    {
        JsonMgr.Instance.SaveDate(data, username);
    }

    //读取
    public UserData LoadUserName(string username)
    {
        return JsonMgr.Instance.LoadDate<UserData>(username);
    }

    //保存用户名
    public void SaveUser(string username)
    {
        if(!accountIndex.userNames.Contains(username))
        {
            accountIndex.userNames.Add(username);
        }
        
        accountIndex.lastUserName = username;
        JsonMgr.Instance.SaveDate(accountIndex, "accounts");
    }



}
