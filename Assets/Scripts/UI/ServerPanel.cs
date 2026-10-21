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
        });
        btnsure.onClick.AddListener(() =>
        {
            //进到大厅场景
        });

    }

    
}
