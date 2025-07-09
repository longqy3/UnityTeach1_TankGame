using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankObject
{
    // 主要是旋转

    // 开火
    // 间隔时间
    public float fireOffSetTime = 1;
    private float time = 0;

    public Transform[] shootPos;
    public GameObject bu;

    public override void Fire()
    {
        for(int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bu, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            // 创建完立即设置子弹的父对象,方便计算属性
            bullet.SetFather(this);
        }
    }

    public override void Wound(TankObject other)
    {
        // 固定坦克不会受伤,删了父对象的Wound方法
    }

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        // 开火间隔设置
        if(time > fireOffSetTime)
        {
            time = 0;
            Fire();
        }
    }
}
