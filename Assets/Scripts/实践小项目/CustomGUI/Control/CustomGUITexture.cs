using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUIControl
{
    public ScaleMode scaleMode = ScaleMode.StretchToFill;
    protected override void StyleOff()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }

    protected override void StyleOn()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }
}
