using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public TMP_InputField tmpuserName;
    public TMP_InputField tmppassWord;
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
                AudioManager.Instance.SetEnterVolume(0.5f);

            }
            else
            {
                //暂停音乐
                AudioManager.Instance.SetEnterVolume(0f);
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
                    UserData data = GameDataMgr.Instance.LoadUserName(tmpuserName.text);

                    if (tmppassWord.text == data.passWord)
                    {
                        data.isRememberPassWord = tgrememberun.isOn;
                        data.isautoLogin = tgautoLogin.isOn;
                        data.isPlayMusic = tgplayMusic.isOn;

                        GameDataMgr.Instance.SetCurrentUser(data);

                        GameDataMgr.Instance.SaveUserData(data, data.userName);
                        GameDataMgr.Instance.SaveUser(data.userName);

                        //判断有没有选过服务器
                        if( GameDataMgr.Instance.UserData.lastServer ==-1)
                        {
                            UIManager.Instance.HidePanel<LoginPanel>();
                            UIManager.Instance.ShowPanel<ChooseServerPanel>();
                            
                        }
                        else
                        {
                            UIManager.Instance.HidePanel<LoginPanel>();
                            UIManager.Instance.ShowPanel<ServerPanel>();
                        }
                    
                    }
                    else
                    {
                        TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                        panel.ChangeInfo("密码错误");
                    }


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

        tmpuserName.text = GameDataMgr.Instance.UserData.userName;
        tgrememberun.SetIsOnWithoutNotify(GameDataMgr.Instance.UserData.isRememberPassWord);
        tgautoLogin.SetIsOnWithoutNotify(GameDataMgr.Instance.UserData.isautoLogin);
        tgplayMusic.isOn = GameDataMgr.Instance.UserData.isPlayMusic;

        if ( tgrememberun.isOn)
        {
            tmppassWord.text = GameDataMgr.Instance.UserData.passWord;

        }
        if (tgautoLogin.isOn)
        {
            //直接进入服务器面板
            UIManager.Instance.HidePanel<LoginPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();

        }
        if (!tgplayMusic.isOn)
        {
            AudioManager.Instance.SetEnterVolume(0f);
        }


    }
    public void saveInfo(string info1, string info2)
    {
        tmpuserName.text = info1;
        tmppassWord.text = info2;
    }
}
