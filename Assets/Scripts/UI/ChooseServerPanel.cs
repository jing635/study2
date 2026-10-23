using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseServerPanel : BasePanel
{
    public ScrollRect svLeft;
    public ScrollRect svRight;
    private List<GameObject> rightItems = new List<GameObject>();

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
        int begin;

        if (data.lastServer <= 0)
        {
            //新号，默认显示第一组
            begin = 1;
        }
        else
        {
            //已选过服务器，显示他所在的那一组
            begin = ((data.lastServer - 1) / 5) * 5 + 1;
        }

        UpdataInfo(begin, begin + 4);

    }

    //跟新右边面板的方法
    public void UpdataInfo(int beginIndex, int endIndex)
    {
        foreach (GameObject item in rightItems)
        {
            Destroy(item);
        }
        rightItems.Clear();

        List<ServerInfo> servers = GameDataMgr.Instance.ServerData;

        if (endIndex > servers.Count)
        {
            endIndex = servers.Count;
        }

        for (int i = beginIndex; i <= endIndex; i++)
        {
            GameObject rb = Instantiate(Resources.Load<GameObject>("UI/RightButton"));
            rb.transform.SetParent(svRight.content, false);

            RightButton rightButton = rb.GetComponent<RightButton>();
            rightButton.updataSelf(i);

            rightItems.Add(rb);
        }
    }
}
