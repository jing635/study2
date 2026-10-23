using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameLoddyPanel : BasePanel
{
    public Button btnDuelArena;
    public Button btnChatacter;
    public Button btnSecretScroll;
    public Button btnSummoning;
    public Button btnNinjaTools;
    public Button btnLevel;
    public Button btnSetting;

    public override void Init()
    {
        btnDuelArena.onClick.AddListener(() =>
        {
            //换到角斗场面板
        });
        btnChatacter.onClick.AddListener(() =>
        {
            //换到角色面板
        });
        btnSecretScroll.onClick.AddListener(() =>
        {
            //换到密卷面板
        });
        btnSummoning.onClick.AddListener(() =>
        {
            //换到通灵面板
        });
        btnNinjaTools.onClick.AddListener(() =>
        {
            //换到关卡面板
        });
        btnSetting.onClick.AddListener(() =>
        {
            //换到设置面板
            UIManager.Instance.HidePanel<GameLoddyPanel>();
            UIManager.Instance.ShowPanel<SettingPanel>();
        });
    }
}
