using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public TankObject faher;

    public float speed = 50;

    public GameObject effObj;

    // 这个和上面的father有什么使用上的区别??
    // 记录拥有者
    public TankObject fatherObj;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // 和别人碰撞时触发
    private void OnTriggerEnter(Collider other)
    {
        // 设计到墙体,敌方也需要
        if (other.CompareTag("Cube") ||
            other.CompareTag("Player") && fatherObj.CompareTag("Monster") ||
            other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
        {
            // 判断受伤   还是里氏替换原则,很典型
            TankObject obj = other.GetComponent<TankObject>();
            if(obj != null)
            {
                obj.Wound(fatherObj);
            }
            // 子弹销毁时创建爆炸特效
            if(effObj != null)
            {
                // 创建特效
                GameObject eff = Instantiate(effObj, transform.position, transform.rotation);

                // 同时控制它的音效开关和大小
                AudioSource aud = eff.GetComponent<AudioSource>();
                aud.mute = !GameDataMgr.Instance.musicData.isOpenSound;
                aud.volume = GameDataMgr.Instance.musicData.soundValue;
            }
            Destroy(gameObject);
        }
    }

    public void SetFather(TankObject obj)
    {
        fatherObj = obj;
    }
}
