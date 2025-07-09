using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    // 获取场景上的控件
    public CustomGUILabel labSocre;
    public CustomGUILabel labTime;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUITexture texHP;
    public CustomGUITexture texMaxHP;
    // 血条控件的宽
    public int hpW = 800;

    [HideInInspector]
    public int nowScore;
    [HideInInspector]
    public float nowTime;
    private int time;

    void Start()
    {
        // 监听界面上控件的事件
        btnQuit.clickEvent += () =>
        {
            // 退出按钮
            // 需要弹一层提示
            QuitPanel.Instance.ShowMe();

            // 暂停时间,0倍速
            Time.timeScale = 0;
        };

        btnSetting.clickEvent += () =>
        {
            // 弹出设置界面
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
    }

    void Update()
    {   
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labTime.content.text = "";
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + " 时";
        }
        if(time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + " 分";
        }
        labTime.content.text += time % 60 + " 秒";
        texMaxHP.guiPos.width = hpW;

    }

    /// <summary>
    /// 提供给外部的方法
    /// </summary>
    /// <param name="score"></param>
    public void Add(int score)
    {
        nowScore += score;
        labSocre.content.text = nowScore.ToString();
    }

    public void UpdateHp(int maxHP, int hp)
    {
        texHP.guiPos.width = (float)hp / maxHP * hpW;
    }
}
