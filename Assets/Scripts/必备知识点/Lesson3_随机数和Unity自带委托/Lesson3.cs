using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson3 : MonoBehaviour
{
    void Start()
    {
        #region 知识点一:随机数

        // 不能这样了
        //Random random = new Random();
        // 也是左闭右开
        int r = Random.Range(0, 100);

        // float的又是左右都闭,有点怪
        float r1 = Random.Range(0f, 100f);

        // 这才是C#的Random,必须加命名空间
        // 但在这里基本只用Unity的就行了
        System.Random random = new System.Random(); 
        random.Next(0,100);
        #endregion

        #region 知识点二:委托

        // 用C#自带的还是要加System.
        // 无返回的Action,有返回的Func

        // Unity的
        UnityAction action = () =>
        {

        };

        UnityAction<int> ac = (i) =>
        {

        };
        #endregion
    }

    void Update()
    {
        
    }
}
