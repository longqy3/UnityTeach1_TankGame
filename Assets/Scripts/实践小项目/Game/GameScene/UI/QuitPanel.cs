using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnquit;
    public CustomGUIButton btnCtn1;
    public CustomGUIButton btnCtn2;

    void Start()
    {
        // 返回开始界面
        btnquit.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        // 继续游戏
        btnCtn1.clickEvent += () =>
        {
            HideMe();
        };
        // 继续游戏
        btnCtn2.clickEvent += () =>
        {
            HideMe();
        };

        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
