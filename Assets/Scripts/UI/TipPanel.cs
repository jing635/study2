using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public TextMeshProUGUI TmpTip;
    public Button btnBack;
    public override void Init()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();
        });
    }

    public void ChangeInfo(string info)
    {
        TmpTip.text = info;
    }

    
}
