using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:class
{
    // 单例模式
    // 不能new了,因为继承了Mono类
    private static T instance;

    public static T Instance => instance;

    private void Awake()
    {
        // 要写约束,申明T只能是class,因为这是用来继承的基类
        // 所以肯定是class
        // 否则无法判断子类的this是什么类型
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        gameObject.SetActive(false);
    }
}
