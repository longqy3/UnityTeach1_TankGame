using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


/// <summary>
/// PlayerPrefs数据管理类,统一管理数据的存取和读取,记住只能存自定义的类,基础那些直接用PlayerPrefs就行了
/// </summary>
public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr instance = new PlayerPrefsDataMgr();

    public static PlayerPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataMgr()
    {

    }

    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据本身</param>
    /// <param name="keyName">存入PlayerPrefs的唯一key,由自己控制</param>
    public void SaveData(object data, string keyName)
    {
        // 通过Type得到对象的所有信息
        // 然后利用keyName自己编规则存入PlayerPrefs


        #region 第一步:获取传入数据对象的所有字段
        // 获取Type,然后获取成员
        Type typeData = data.GetType();
        FieldInfo[] field = typeData.GetFields();
        #endregion

        #region 第二步:自己定义一个Key的规则,进行数据存储
        // 主要是通过PlayerPrefs存储信息,要在里面创建唯一的Key
        // 所以需要自己定义一个规则,保证Key唯一
        // 规则: keyName_数据类型_字段类型_字段名


        #endregion

        #region 第三步:遍历这些字段,进行数据存储
        // 对每个信息进行存储
        FieldInfo info;
        // FieldInfo有方法直接获取字段的类型和名字
        // 类型: FieldInfo.FieldType.Name
        // 名字: FieldInfo.Name
        string fieldName = "";
        for (int i = 0; i < field.Length; i++)
        {
            info = field[i];
            fieldName = keyName + "_" + typeData.Name + "_" + 
                info.FieldType.Name +"_" + info.Name;

            // 获取info的值,然后存入PlayerPrefs中
            // 这里是在外部封装一个方法
            SaveValue(info.GetValue(data), fieldName);
        }
        // 保存一下,防止游戏突然崩溃
        PlayerPrefs.Save();
        #endregion
    }

    private void SaveValue(object value, string fieldName)
    {
        // 根据数据是什么类型的再调用对应的API
        // PlayerPrefs只有3种类型的存储API
        Type fieldType = value.GetType();
        if(fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(fieldName, (int)value);
        }
        else if(fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(fieldName, (float)value);
        }
        else if(fieldType == typeof(string))
        {
            PlayerPrefs.SetString(fieldName, value.ToString());
        }
        else if( fieldType == typeof(bool))
        {
            // 自动定规则,让没有这种类型的API也能存进去
            PlayerPrefs.SetInt(fieldName, (bool)value ?  1 : 0);
        }

        // 通过判断fieldType的字段是不是IList的子类,从而判断该字段是不是List类型的
        // 这个有点东西
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            // 父类装子类
            IList list = (IList)value;
            // 先存数量
            PlayerPrefs.SetInt(fieldName + "_ListCount", list.Count);

            int index = 0;
            foreach ( object item in list )
            {
                // 再递归存储具体的值
                SaveValue(item, fieldName + "_ListData" + index);
                index++;
            }
        }

        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dict = (IDictionary)value;
            PlayerPrefs.SetInt(fieldName + "DicCount", dict.Count);
            int index = 0;
            foreach (object item in dict.Keys)
            {
                SaveValue(item, fieldName + "_Key_" + index);
                SaveValue(dict[item], fieldName + "_Value_" + index);
                index++;
            }
        }

        // 默认不是基础类型时,就是自定义类型了,其他类型还不考虑
        else
        {
            SaveData(value, fieldName);
        }
    }


    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">数据的Type</param>
    /// <param name="keyName">唯一Key</param>
    /// <returns></returns>
    public object LoadData(Type type, string keyName)
    {
        // 不用object作为传入参数而是Type
        // 目的是不用在外面再声明一个变量,省一行代码
        // 然后内部帮创建再返回出去

        // 根据传入的Type来创建对象,用来存储数据,最后就是返回该对象
        object data = Activator.CreateInstance(type);
        // 得到所有字段
        FieldInfo[] fieldInfos = type.GetFields();
        string fieldName = "";
        FieldInfo temp;
        for(int i = 0;i < fieldInfos.Length;i++)
        {
            temp = fieldInfos[i];
            // 规则一定是要和存的时候一样
            fieldName = keyName + "_" + type.Name + "_" + temp.FieldType.Name + "_" + temp.Name;
            // 然后填充数据到data
            // 这个方法不太懂
            temp.SetValue(data,LoadValue(temp.FieldType, fieldName));
        }

        return data;
    }

    private object LoadValue(Type fieldType, string fieldName)
    {
        // 根据数据类型来判断 用哪个类型的PlayerPrefs的API
        if(fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(fieldName, 0);
        }
        else if(fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(fieldName, 0);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(fieldName, "");
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(fieldName, 0) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            // 先拿长度
            int count = PlayerPrefs.GetInt(fieldName + "_ListCount", 0);
            // 再快速实例化出一个List
            IList list = Activator.CreateInstance(fieldType) as IList;
            for(int i = 0;  i < count; i++)
            {
                // 目的是要得到List中的泛型类型
                // 这个也不太懂
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], fieldName + "_ListData" + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int count = PlayerPrefs.GetInt(fieldName + "DicCount", 0);
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;
            Type[] kvType = fieldType.GetGenericArguments();
            for(int i = 0;i < count; i++)
            {
                dic.Add(LoadValue(kvType[0], fieldName + "_Key_" + i),
                        LoadValue(kvType[1], fieldName + "_Value_" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(fieldType, fieldName);
        }
    }
}
