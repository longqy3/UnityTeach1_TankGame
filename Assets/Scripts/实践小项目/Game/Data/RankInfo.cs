using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 排行榜单条数据
/// </summary>
public class RankInfo 
{
    public string name;
    public int score;
    public float time;

    // 读数据时默认调用无参构造,避免出错
    public RankInfo() { }

    public RankInfo(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }   
}

public class RankList
{
    public List<RankInfo> list = new List<RankInfo>();
}
