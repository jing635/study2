using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseServerPanel : BasePanel
{
    public ScrollRect svLeft;
    public ScrollRect svRight;
    
    public override void Init()
    {
        //得到左边按钮的数据
        List<ServerInfo> servers = GameDataMgr.Instance.ServerData;
        //判断要创建多少个按钮
        int num = (servers.Count + 4) / 5;
        for (int i = 0; i < num; i++)
        {
            GameObject lb = Instantiate(Resources.Load<GameObject>("UI/LeftButton"));
            lb.transform.SetParent(svLeft.content, false);

            LeftButton leftButton = lb.GetComponent<LeftButton>();

            int begin = i * 5 + 1;
            int end = i * 5 + 5;
            if (servers.Count < end)
            {
                end = servers.Count;
            }

            leftButton.UpdataSelf(begin, end);
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();

        //得到用户的服务器，更新右边面板
        UserData data = GameDataMgr.Instance.UserData;
        List<ServerInfo> servers = GameDataMgr.Instance.ServerData;

        if (data.lastServer == -1)
        {
            UpdataInfo(1, 5);
        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                if ((i * 5 + 1) < data.lastServer && (i * 5 + 5) > data.lastServer)
                {
                    int begin = i * 5 + 1;
                    int end = i * 5 + 5;
                    if (end > servers.Count)
                    {
                        end = servers.Count;
                    }
                    UpdataInfo(begin, end);
                }
            }
        }
        
        

    }

    //跟新右边面板的方法
    public void UpdataInfo(int beginindex, int endindex)
    {
        for (int i = beginindex; i < endindex; i++)
        {
            GameObject rb = Instantiate(Resources.Load<GameObject>("UI/RightButton"));
            rb.transform.SetParent (svRight.content, false);

            RightButton rightButton = rb.GetComponent<RightButton>();
            rightButton.updataSelf(beginindex);
        }
    }
}
