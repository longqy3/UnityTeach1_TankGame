using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    public AudioSource audio;

    private void Awake()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
        // 初始化时,根据后台保存的数据进行设置
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
       
    }
    /// <summary>
    /// 改变背景音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audio.volume = value;
    }
    /// <summary>
    /// 改变背景音乐开关
    /// </summary>
    /// <param name="open"></param>
    public void ChangeOpen(bool open)
    {
        // 开启就是不静音
        // 关闭就是静音
        audio.mute = !open;
    }

}
