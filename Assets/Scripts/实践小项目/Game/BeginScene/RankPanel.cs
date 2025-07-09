using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    // 关联公共UI
    public CustomGUIButton btnClose;
    

    // 用List存储前端的数据
    // 因为数据太多了
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();

    private void Start()
    {
        // 处理逻辑
        for (int i = 1; i <= 6; i++)
        {
            // 加斜杠可以直接查子对象的子对象
            labName.Add(transform.Find("PlayerName/PlayerName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(transform.Find("PlayerScore/PlayerScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(transform.Find("PlayerTime/PlayerTime" + i).GetComponent<CustomGUILabel>());
        }

        // 监听事件,点击按钮触发的事件
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };

        // 还是一开始隐藏排行榜
        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        updatePanelInfo();
    }

    public void updatePanelInfo()
    {
        // 更新数据
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            labName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            if (time / 3600 > 0)
            {
                labTime[i].content.text = time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || time % 3600 > 0)
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            labTime[i].content.text += time % 3600 + "秒";
        }
    }

}
