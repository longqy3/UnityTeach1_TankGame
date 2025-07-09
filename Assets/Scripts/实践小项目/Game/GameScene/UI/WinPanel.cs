using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    // 关联控件
    public CustomGUIInput input;
    public CustomGUIButton btnQuit;

    private void Start()
    {
        btnQuit.clickEvent += () =>
        {
            Time.timeScale = 1;
            // 加排行榜数据, 并回到主场景
            GameDataMgr.Instance.AddRankInfo(input.content.text,
                GamePanel.Instance.nowScore,
                GamePanel.Instance.nowTime);

            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }
}
