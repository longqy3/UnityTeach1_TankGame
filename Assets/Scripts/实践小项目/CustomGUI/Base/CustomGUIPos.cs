using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_Alignment_Type
{
    Up,
    Down, 
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
}

[System.Serializable]
public class CustomGUIPos 
{
    // 主要是处理控件相关的内容
    // 要完成分辨率自适应的相关计算

    // 该位置信息会返回给外部 用于描绘控件
    // 需要对它进行计算

    private Rect rPos = new Rect(0, 0, 100, 100);

    // 屏幕九宫格对齐方式
    public E_Alignment_Type screen_Alignment_Type = E_Alignment_Type.Center;
    // 控件中心九宫格对齐方式
    public E_Alignment_Type control_center_Alignment_Type = E_Alignment_Type.Center;
    // 偏移位置
    public Vector2 pos;
    public float width;
    public float height;

    // 用于计算中心点偏移量
    private Vector2 centerPos;

    // 计算中心点偏移的方法
    private void CalcCenter()
    {
        switch (control_center_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }

    // 计算相对屏幕偏移的方法
    private void CalcPos()
    {
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height / 2+ centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Up:
                rPos.x = centerPos.x + pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Down:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Up:
                rPos.x = Screen.width + centerPos.x + pos.x;
                rPos.y = centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Down:
                rPos.x = Screen.width + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y + pos.y;
                break;
        }
    }
    public Rect Pos
    {
        get
        {
            // 计算中心点偏移量
            CalcCenter();
            // 控件相对屏幕偏移
            CalcPos();
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }

}
