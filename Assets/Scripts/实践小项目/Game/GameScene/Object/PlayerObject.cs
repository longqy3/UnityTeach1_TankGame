using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : TankObject
{
    // 武器
    public WeaponObj nowWeapon;

    public Transform weaponPos;

    public float fireRate = 0.2f;
    private float time = 0f;

    void Update()
    {
        // 基础控制
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * speed *  Time.deltaTime);
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roSpeed * Time.deltaTime);
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headSpeed * Time.deltaTime);
        // 控制频率
        if (Input.GetMouseButton(0) && Time.time - time > fireRate)
        {
            time = Time.time;
            Fire();
        }
            
    }

    public override void Fire()
    {
        if(nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        enabled = false;
        // 不执行,防止玩家上的摄像头被删,影响界面
        //base.Dead();
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }

    public override void Wound(TankObject other)
    {
        base.Wound(other);
        // 更新血条
        GamePanel.Instance.UpdateHp(maxHp, hp);
    }

    // 切换武器的方法,提供给外部使用
    public void ChangeWeapon(GameObject obj)
    {
        if(nowWeapon != null)
        {
            // 为什么是销毁依附的gameobject
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        // 切换武器 设置父对象 保证缩放不出错
        GameObject wanponObj = Instantiate(obj, weaponPos, false);
        nowWeapon = wanponObj.GetComponent<WeaponObj>();

        // 设置武器拥有者
        nowWeapon.SetFather(this);
    }
}
