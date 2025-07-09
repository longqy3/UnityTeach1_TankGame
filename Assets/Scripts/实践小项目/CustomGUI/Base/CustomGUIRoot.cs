using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] allGUI;
    void Start()
    {
        allGUI = GetComponentsInChildren<CustomGUIControl>();
    }


    private void OnGUI()
    {
        // 通过每次绘制之前,获得子对象上控件的父类脚本
        // 这句会浪费性能,每次都会获取所有的脚本,所以要换个位置,测试的时候还要优化一下
        //if(!Application.isPlaying)
            allGUI = GetComponentsInChildren<CustomGUIControl>();
        for(int i = 0; i < allGUI.Length; i++)
        {
            allGUI[i].DrawGUI();
        }
    }
}
