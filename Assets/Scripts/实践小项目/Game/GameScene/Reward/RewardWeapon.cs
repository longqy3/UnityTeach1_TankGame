using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardWeapon : MonoBehaviour
{
    // 还是用拖的
    public GameObject[] obj;

    // 拖个特效过来
    public GameObject eff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 换武器
            int r = Random.Range(0, obj.Length);
            PlayerObject player = other.GetComponent<PlayerObject>();
            player.ChangeWeapon(obj[r]);

            // 获取的特效
            GameObject ef = Instantiate(eff,transform.position, transform.rotation);
            // 同步音效
            AudioSource audio = ef.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.soundValue;
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            // 销毁图标
            Destroy(gameObject);
        }
    }
}
