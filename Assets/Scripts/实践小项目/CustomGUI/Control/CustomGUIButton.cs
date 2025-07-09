using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    public event UnityAction clickEvent;
    protected override void StyleOff()
    {
        if (GUI.Button(guiPos.Pos, content))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOn()
    {
        if (GUI.Button(guiPos.Pos, content,style))
        {
            clickEvent?.Invoke();
        }
    }
}
