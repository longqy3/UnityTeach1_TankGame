using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIInput : CustomGUIControl
{
    public event UnityAction<string> textChange;

    private string oldStr = "";
    protected override void StyleOff()
    {
        string input = GUI.TextField(guiPos.Pos, content.text);
        if(input != content.text)
        {
            content.text = input;
            if(oldStr != input)
            {
                textChange?.Invoke(oldStr);
                oldStr = content.text;
            }
        }
    }

    protected override void StyleOn()
    {
        string input = GUI.TextField(guiPos.Pos, content.text,style);
        if (input != content.text)
        {
            content.text = input;
            if (oldStr != input)
            {
                textChange?.Invoke(oldStr);
                oldStr = content.text;
            }
        }
    }
}
