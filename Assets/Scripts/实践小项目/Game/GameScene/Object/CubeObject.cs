using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    public GameObject[] rewards;

    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        // 销毁打中自己的子弹
        // 子弹里有了

        Destroy(gameObject);

        // 随机创建奖励
        int index = Random.Range(0, 100);
        if(index < 50)
        {
            index = Random.Range(0,rewards.Length);
            Instantiate(rewards[index], transform.position,transform.rotation);
        }
        Instantiate(deadEff,transform.position,transform.rotation);

        // 同步音效
        AudioSource audio = deadEff.GetComponent<AudioSource>();
        audio.volume = GameDataMgr.Instance.musicData.soundValue;
        audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;
    }
}
