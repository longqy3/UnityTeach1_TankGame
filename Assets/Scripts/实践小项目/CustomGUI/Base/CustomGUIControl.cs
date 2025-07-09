using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Style_OnOrOff
{
    On,
    Off,
}
// 提前控件的共同表现
public abstract class CustomGUIControl : MonoBehaviour
{
    // 位置信息
    public CustomGUIPos guiPos;

    // 显示内容信息
    public GUIContent content;

    // 自定义样式是否开启
    public E_Style_OnOrOff styleOnOrOff = E_Style_OnOrOff.Off;

    // 自定义样式
    public GUIStyle style;



    public void DrawGUI()
    {
        switch (styleOnOrOff)
        {
            case E_Style_OnOrOff.On:
                StyleOn();
                break;
            case E_Style_OnOrOff.Off:
                StyleOff();
                break;
        }
    }

    // 开启style时的绘制
    protected abstract void StyleOn();

    // 关闭style时的绘制
    protected abstract void StyleOff();
}
