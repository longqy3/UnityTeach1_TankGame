using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson1 : MonoBehaviour
{
   


    void Start()
    {
        
    }

    void Update()
    {
        #region 知识点一:场景切换

        // 这居然是在实践里学的,但GUI里又用到,学习顺序出错了?
        // 然后外面还要在build setting里添加场景才能有效
        // build setting里第一个场景是游戏打开时的默认场景
        SceneManager.LoadScene("其他场景名字");
        #endregion

        #region 知识点二:游戏退出

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 编辑模式下退不出去
            // 只能在游戏发布后才能执行退出
            Application.Quit();
        }

        #endregion
    }
}
