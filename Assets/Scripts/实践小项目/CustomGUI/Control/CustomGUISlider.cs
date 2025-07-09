using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_Slider_Type
{
    Horizontial,
    Vertical,
}

public class CustomGUISlider : CustomGUIControl
{
    public float minValue = 0;
    public float maxValue = 1;
    public float value = 0;
    // 水平或竖直
    public E_Slider_Type silderType = E_Slider_Type.Horizontial;
    // 小按钮的Style
    public GUIStyle styleThumb;

    public event UnityAction<float> changeValue;

    private float oldValue;
    protected override void StyleOff()
    {
        switch (silderType)
        {
            case E_Slider_Type.Horizontial:
                value = GUI.HorizontalSlider(guiPos.Pos, value, minValue, maxValue);
                break;
            case E_Slider_Type.Vertical:
                value = GUI.VerticalSlider(guiPos.Pos, value, minValue, maxValue);
                break;
        }

        if(oldValue != value)
        {
            oldValue = value;
            changeValue?.Invoke(value);
        }
    }

    protected override void StyleOn()
    {
        switch (silderType)
        {
            case E_Slider_Type.Horizontial:
                value = GUI.HorizontalSlider(guiPos.Pos, value, minValue, maxValue,style,styleThumb);
                break;
            case E_Slider_Type.Vertical:
                value = GUI.VerticalSlider(guiPos.Pos, value, minValue, maxValue, style, styleThumb);
                break;
        }

        if (oldValue != value)
        {
            oldValue = value;
            changeValue?.Invoke(value);
        }
    }
}
