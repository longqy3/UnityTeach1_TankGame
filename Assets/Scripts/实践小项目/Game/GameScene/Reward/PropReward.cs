using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PropReward
{
    Hp,
    Atk,
    Def,
    MaxHp,
} 
public class PropReward : MonoBehaviour
{
    public E_PropReward e_P;

    // 拖个特效
    public GameObject eff;

    // 默认加的值
    public int value = 2;
    private void OnTriggerEnter(Collider other)
    {
        PlayerObject player = other.GetComponent<PlayerObject>();
        switch (e_P)
        {
            case E_PropReward.Hp:
                player.hp += value;
                if(player.hp > GamePanel.Instance.hpW)
                {
                    player.hp = GamePanel.Instance.hpW;
                }
                GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                break;
            case E_PropReward.Atk:
                player.atk += value;
                break;
            case E_PropReward.Def:
                player.def += value;
                break;
            case E_PropReward.MaxHp:
                player.maxHp += value;
                GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                break;
        }

        // 设置特效
        // 获取的特效
        GameObject ef = Instantiate(eff, transform.position, transform.rotation);
        // 同步音效
        AudioSource audio = ef.GetComponent<AudioSource>();
        audio.volume = GameDataMgr.Instance.musicData.soundValue;
        audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(gameObject);
    }

}
