using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour
{
    public Button btnleft;
    public TextMeshProUGUI Servers;
    private int beginIndex;
    private int endIndex;

    // Start is called before the first frame update
    void Start()
    {
        btnleft.onClick.AddListener(() =>
        {
            //更新右边面板
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdataInfo(beginIndex, endIndex);
        });
    }

    //更新自己的方法
    public void UpdataSelf(int beginIndex, int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;
        Servers.text = beginIndex + "-" + endIndex;
    }

    
}
