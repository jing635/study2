using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public TMP_InputField tmpUsername;
    public TMP_InputField tmpPassword;
    public Button btnBack;
    public Button btnSure;
    public override void Init()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<RegisterPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();

        });

        btnSure.onClick.AddListener(() =>
        {
            if ( tmpUsername.text.Length < 7 || tmpPassword.text.Length < 7)
            {
                TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                panel.ChangeInfo("账号和密码必须大于6位数");
            }
            else
            {
                if (GameDataMgr.Instance.IsExist(tmpUsername.text))
                {
                    TipPanel panel = UIManager.Instance.ShowPanel<TipPanel>();
                    panel.ChangeInfo("用户已存在");
                }
                else
                {
                    UserData data = new UserData();

                    data.userName = tmpUsername.text;
                    data.passWord = tmpPassword.text;

                    GameDataMgr.Instance.SetCurrentUser(data);

                    GameDataMgr.Instance.SaveUserData(data, data.userName);
                    GameDataMgr.Instance.SaveUser(data.userName);

                    UIManager.Instance.HidePanel<RegisterPanel>();
                    UIManager.Instance.ShowPanel<LoginPanel>();

                }
            }
        });
    }

   
    
}
