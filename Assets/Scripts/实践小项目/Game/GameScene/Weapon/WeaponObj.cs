using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    // 实例化子弹
    public GameObject bullet;

    // 由外部决定有几个发射位置
    // 但感觉直接拖的话,武器变动时候怎么办?
    public Transform[] shootPos;

    // 记录拥有者
    public TankObject fatherObj;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetFather(TankObject obj)
    {
        fatherObj = obj;
    }

    public void Fire()
    {
        // 根据位置创建子弹
        for(int i = 0; i < shootPos.Length; i++)
        {
            // 创建子弹预设体
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            // 控制子弹做什么
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherObj);
        }
    }
}
