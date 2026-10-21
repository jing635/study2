using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public TextMeshProUGUI tmpuserName;
    public TextMeshProUGUI tmppassWord;
    public Toggle tgrememberun;
    public Toggle tgautoLogin;
    public Toggle tgplayMusic;
    public Button btnRegister;
    public Button btnLogin;

    

    public override void Init()
    {
        tgrememberun.onValueChanged.AddListener((isOn) =>
        {
            //取消自动登录
            if(!isOn)
            {
                tgautoLogin.isOn = false;
            }
        });

        tgautoLogin.onValueChanged.AddListener((isOn) =>
        {
            //取消记住密码
            if(!isOn)
            {
                tgrememberun.isOn = false;
            }
            else
            {
                tgrememberun.isOn = true;
            }
        });

        tgplayMusic.onValueChanged.AddListener((isOn) =>
        {
            if(isOn)
            {
                //播放音乐

            }
            else
            {
                //暂停音乐
            }
        });
        
        btnLogin.onClick.AddListener(() =>
        {
            if ( tmpuserName.text.Length < 7 ||tmppassWord.text.Length < 7)
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("账号和密码必须大于6位数");
            }
            else
            {
                if ( GameDataMgr.Instance.IsExist(tmpuserName.text) )
                {
                    //如果是上次服务器不是空，就进服务器面板
                    //保存用户信息
                    GameDataMgr.Instance.UserData.isRememberPassWord = tgrememberun.isOn;
                    GameDataMgr.Instance.UserData.isautoLogin = tgautoLogin.isOn;
                    GameDataMgr.Instance.UserData.isPlayMusic = tgplayMusic.isOn;
                    GameDataMgr.Instance.SaveUserData(tmpuserName.text);
                    //记录登录用户
                    GameDataMgr.Instance.savelastUserName(tmpuserName.text);
                    //换到服务器面板
                    //为空就进选择服务器面板
                }
                else
                {
                    //用户不存在
                    TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                    panel.ChangeInfo("用户不存在");
                }
            }
           
        });

        btnRegister.onClick.AddListener(() =>
        {
            //换到注册面板
            UIManager.Instance.ShowPanel<RegisterPanel>();
            UIManager.Instance.HidePanel<LoginPanel>();

        });
    }

    public override void ShowMe()
    {
        base.ShowMe();

        string filename = GameDataMgr.Instance.lastUserName;
        UserData data = JsonMgr.Instance.LoadDate<UserData>(filename);

        tmpuserName.text = data.userName;
        tmppassWord.text = data.passWord;
        tgrememberun.isOn = data.isRememberPassWord;
        tgautoLogin.isOn = data.isautoLogin;
        tgplayMusic.isOn = data.isPlayMusic;

        if (tgrememberun.isOn)
        {
            tmppassWord.text = data.passWord;
        }
        if (tgautoLogin.isOn)
        {
            //直接跳到服务器面板
        }
        if (tgplayMusic.isOn)
        {
            //播放背景音乐
        }


    }
}
