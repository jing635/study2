using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
{
    public TextMeshProUGUI Servername;
    public Button btnright;
    private int id;
    private string rightbuttonname;

    // Start is called before the first frame update
    void Start()
    {
        btnright.onClick.AddListener(() =>
        {
            //记下选择的服务器
            UserData data = GameDataMgr.Instance.UserData;
            data.lastServer = id;

            GameDataMgr.Instance.SaveUserData(data, data.userName);
            //换面板
            UIManager.Instance.HidePanel<ChooseServerPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //更新自己的方法
    public void updataSelf(int id)
    {
        ServerInfo server = GameDataMgr.Instance.ServerData[id - 1];
        this.id = server.id;
        this.rightbuttonname = server.name;
        Servername.text = id + "区  " + server.name;
    }
}
