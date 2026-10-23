using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Toggle tgMusic;
    public Toggle tgSound;
    public Slider sdMusic;
    public Slider sdSound;
    public Button btnReturn;
    public Button btnBack;
    private UserData musicdata;


    public override void Init()
    {
        tgMusic.onValueChanged.AddListener((isOn) =>
        {
            //控制音乐开关
            if (isOn)
            {
                sdMusic.interactable = true;
                AudioManager.Instance.SetMusicVolume(sdMusic.value);
            }
            else
            {
                sdMusic.interactable= false;
                AudioManager.Instance.SetMusicVolume(0f);
            }
            GameDataMgr.Instance.SaveUserData(musicdata,musicdata.userName);
            
        });
        tgSound.onValueChanged.AddListener((isOn) =>
        {
            //控制音效开关
            if (isOn)
            {
                sdSound.interactable = true;
                AudioManager.Instance.SetSoundVolume(sdSound.value);
            }
            else
            {
                sdSound.interactable = false;
                AudioManager.Instance.SetSoundVolume(0f);
            }
            GameDataMgr.Instance.SaveUserData(musicdata, musicdata.userName);
        });
        sdMusic.onValueChanged.AddListener((value) =>
        {
            //控制音量大小
            AudioManager.Instance.SetMusicVolume(value);
            GameDataMgr.Instance.SaveUserData(musicdata, musicdata.userName);

        });
        sdSound.onValueChanged.AddListener((value) =>
        {
            //控制音效大小
            AudioManager.Instance.SetSoundVolume(value);
            GameDataMgr.Instance.SaveUserData(musicdata, musicdata.userName);

        });
        btnReturn.onClick.AddListener(() =>
        {
            //换到大厅面板
            UIManager.Instance.HidePanel<SettingPanel>();
            UIManager.Instance.ShowPanel<GameLoddyPanel>();

            
        });
        btnBack.onClick.AddListener(() =>
        {
            //换到登陆场景
            SceneManager.LoadScene("LoginScene");


        });
    }

    // Start is called before the first frame update
    void Start()
    {
        musicdata = GameDataMgr.Instance.UserData;
    }
    public override void ShowMe()
    {
        base.ShowMe();

        
        tgMusic.isOn = musicdata.music;
        tgSound.isOn = musicdata.sound;
        sdMusic.value = musicdata.musicvolume;
        sdSound.value = musicdata.soundvolume;
    }

   
}
