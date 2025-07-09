using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// 游戏数据管理类,单例模式
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;


    // 音乐对象
    public  MusicData musicData;
    // 排行榜对象
    public RankList rankData;


    private GameDataMgr()
    {
        // 初始化音乐数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        if (!musicData.notFirst)
        {
            musicData.notFirst = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }

        // 初始化排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }

    // 提供一些API给外部 方便数据存储

    // 给排行榜加数据
    public void AddRankInfo(string name, int score, float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        rankData.list.Sort((a, b) => a.time < b.time ? -1:1);
        for(int i = rankData.list.Count - 1; i >= 10; i--)
        {
            rankData.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }

    // 开关音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        BKMusic.Instance.ChangeOpen(isOpen);

        // 改变后存储
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    // 开关音效
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    // 改变音乐大小
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        BKMusic.Instance.ChangeValue(value);

        // 改变后保存
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    // 改变音效大小
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
