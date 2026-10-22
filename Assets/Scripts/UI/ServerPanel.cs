using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Button btnchange;
    public Button btnsure;
    public TextMeshProUGUI tmpserver;

    public override void Init()
    {
        btnchange.onClick.AddListener(() =>
        {
            //换到选择服务器面板
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<ChooseServerPanel>();

            
        });
        btnsure.onClick.AddListener(() =>
        {
            //进到大厅场景
        });

    }

    public override void ShowMe()
    {
        base.ShowMe();

        UserData data = GameDataMgr.Instance.UserData;
        ServerInfo info = GameDataMgr.Instance.ServerData[data.lastServer-1];
        tmpserver.text = info.id + "区  " + info.name;
    }

    
}
