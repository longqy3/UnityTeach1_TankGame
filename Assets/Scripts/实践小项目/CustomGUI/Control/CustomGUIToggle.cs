using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    public bool isSel;
    public event UnityAction<bool> changeValue;

    private bool isOldSel;
    protected override void StyleOff()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content);
        // 只有当变化时才调用方法,不需要一直触发该事件
        if(isOldSel != isSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
        

    }

    protected override void StyleOn()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content,style);
        if (isOldSel != isSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }
}
