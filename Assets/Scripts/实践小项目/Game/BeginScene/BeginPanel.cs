using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    void Start()
    {
        // 开始设置光标,让光标进去后进被锁住
        Cursor.lockState = CursorLockMode.Confined;
        // 通过在Start里给bttton加事件来添加按钮的功能,而不是在Update里一直if判断了
        btnBegin.clickEvent += () =>
        {
            // 切换到游戏场景
            SceneManager.LoadScene("GameScene");
        };

        btnSetting.clickEvent += () =>
        {
            // 打开设置面板
            HideMe();
            SettingPanel.Instance.ShowMe();
        };

        btnQuit.clickEvent += () =>
        {
            // 退出游戏
            Application.Quit();
        };

        btnRank.clickEvent += () =>
        {
            // 打开排行榜
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }
}
