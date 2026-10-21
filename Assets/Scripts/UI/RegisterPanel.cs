using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public TextMeshProUGUI tmpUsername;
    public TextMeshProUGUI tmpPassword;
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
                GameDataMgr.Instance.UserData.userName = tmpUsername.text;
                GameDataMgr.Instance.UserData.passWord = tmpPassword.text;
                GameDataMgr.Instance.SaveUserData(tmpUsername.text);

                UIManager.Instance.HidePanel<RegisterPanel>();
                UIManager.Instance.ShowPanel<LoginPanel>();
            }
        });
    }

   
    
}
