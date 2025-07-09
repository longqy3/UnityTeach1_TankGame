using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankObject
{
    // 1.来回移动
    // 当前朝向的点
    private Transform targetPos;
    // 随机获得的点
    public Transform[] randomPos;

    // 2.盯着玩家
    // 看向的点
    public Transform lookAtTarget;

    // 3.进入范围后 隔一段时间开火
    // 开火距离
    public float fireDic = 5;
    // 开火间隔
    public float fireOffSetTime = 0.5f;
    public float nowTime;
    // 开火点
    public Transform[] shootPos;
    // 子弹预设体
    public GameObject bullet;

    // GUI
    public Texture bkT;
    public Texture hpT;
    // 结构体不用new
    private Rect bkRect;
    private Rect hpRect;
    // 设置显示时间,不用一直显示
    public float showTime;
    private void Start()
    {
        RandomPos();
    }

    private void Update()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // 获取两点的距离,当移动到目标点附近时重新定位
        if (Vector3.Distance(transform.position, targetPos.position) < 0.05f)
            RandomPos();    


        if(lookAtTarget != null)
        {
            
            transform.LookAt(lookAtTarget);
            if (Vector3.Distance(transform.position, lookAtTarget.position) <= fireDic)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffSetTime)
                {
                    nowTime = 0;
                    Fire();
                }
            }
        }
            
    }

    private void RandomPos()
    {
        if (randomPos == null)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Fire()
    {
        for(int i = 0; i< shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(this);
        
        }
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.Add(10);
    }

    // 直接在这里画GUI
    // 有两次坐标转换:怪物转屏幕,屏幕转GUI
    private void OnGUI()
    {
        if(showTime >= 0)
        {
            showTime -= Time.deltaTime;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            screenPos.y = Screen.height - screenPos.y;

            // 绘制
            // 背景图
            bkRect.x = screenPos.x - 180;
            bkRect.y = screenPos.y - 180;
            bkRect.width = 300;
            bkRect.height = 40;
            GUI.DrawTexture(bkRect, bkT);

            // 血量图
            hpRect.x = screenPos.x - 180;
            hpRect.y = screenPos.y - 180;
            hpRect.width = (float)hp / maxHp * 300f;
            hpRect.height = 40;
            GUI.DrawTexture(hpRect, hpT);
        }
    }

    public override void Wound(TankObject other)
    {
        base.Wound(other);
        // 显示时间
        showTime = 3;
    }
}
