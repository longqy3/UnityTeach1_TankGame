using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    // 两个Slider 两个Toggle 一个Button
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleSound;
    public CustomGUIButton quit;

    void Start()
    {
        // 监听对应事件,处理逻辑

        // 控制音乐大小
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);
        // 控制音效大小
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        // 控制音乐开关
        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        // 控制音效开关
        toggleSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        quit.clickEvent += () =>
        {
            // 关闭设置界面
            HideMe();

            // 由于开始界面和游戏界面共用,且功能有些差异,所以需要区分
            if(SceneManager.GetActiveScene().name == "BeginScene")
                BeginPanel.Instance.ShowMe();
        };

        HideMe();
    }

    public void updatePanelInfo()
    {
        // 面板上的信息也实时更新
        MusicData data = GameDataMgr.Instance.musicData;

        // 设置面板内容
        sliderMusic.value = data.bkValue;
        sliderSound.value = data.soundValue;
        toggleMusic.isSel = data.isOpenBK;
        toggleSound.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        base.ShowMe();

        // 每次显示内容时 把面板上的内容也更新一遍 也就是读PlayerPrefsDataMgr里存储的数据
        // 先更新再ShowMe会不会好点?虽然是同步存储的,结果没什么区别
        updatePanelInfo();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
