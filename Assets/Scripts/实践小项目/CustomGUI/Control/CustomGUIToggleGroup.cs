using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour
{
    // 要运行时才能看到效果,因为是Start里的!!!!
    // 这样写好像也没有实时执行那个特性



    public CustomGUIToggle[] customGUIToggles;

    private CustomGUIToggle tempToggle;
    private void Start()
    {
        if (customGUIToggles.Length == 0)
            return;

        // 给选择的toggle添加事件,让其他toggle变成false
        for (int i = 0; i < customGUIToggles.Length; i++)
        {
            CustomGUIToggle temp = customGUIToggles[i];
            temp.changeValue += (value) =>
            {
                if(value)
                {
                    for(int j = 0; j < customGUIToggles.Length; j++)
                    {
                        if (customGUIToggles[j] != temp)
                        {
                            customGUIToggles[j].isSel = false;
                        }
                    }
                    // 记录上一次为true的toggle
                    tempToggle = temp;
                }
                // 来判断是不是上次为true的toggle,如果是就不变,让选项保持有一个是选中的
                else if (temp == tempToggle)
                {
                    temp.isSel = true;
                }
            };
        }
    }
}
