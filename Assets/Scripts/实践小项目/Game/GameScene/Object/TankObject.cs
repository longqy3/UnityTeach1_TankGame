using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankObject : MonoBehaviour
{
    // 基本属性
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    public GameObject tankHead;

    public float speed = 5;
    public float roSpeed = 80;
    public float headSpeed = 50;

    // 死亡特效
    public GameObject deadEff;

    public abstract void Fire();

    public virtual void Dead()
    {
        Destroy(gameObject);
        if(deadEff != null)
        {
            GameObject eff = Instantiate(deadEff, transform.position, transform.rotation);
            // 控制特效的音效
            AudioSource ads = eff.GetComponent<AudioSource>();
            ads.volume = GameDataMgr.Instance.musicData.soundValue;
            // 这个是静音,不是中断,这样打开的时候就不用重新开始读音频了
            ads.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            // 避免没有勾选 Play On Awake
            ads.Play();
        }
    }

    public virtual void Wound(TankObject other)
    {
        int dmg = other.atk - def;
        if (dmg <= 0)
            return;

        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

}
