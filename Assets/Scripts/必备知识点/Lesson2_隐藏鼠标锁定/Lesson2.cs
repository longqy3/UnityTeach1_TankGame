using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    public Texture2D tex;

    void Start()
    {

        #region 知识点一:隐藏鼠标

        Cursor.visible = false;

        #endregion

        #region 知识点二:锁定鼠标

        // None 不锁定
        // Locked 锁定在中心点且隐藏鼠标,在编辑模式下可以通过esc来拜托锁定
        // Confined 被限制在窗口范围内
        Cursor.lockState = CursorLockMode.Locked;

        #endregion

        #region 知识点三:设置鼠标图片

        // 参数一:图片
        // 参数二:相对图片左上角的偏移位置
        // 参数三:平台支持的光标模式(硬件或软件)
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
        #endregion
    }

    void Update()
    {
        
    }
}
