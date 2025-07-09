using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    private float h = 15;
    private Vector3 pos;

    // 摄像头的写在这个生命周期,避免渲染出错
    void LateUpdate()
    {
        if(target == null)
            return;
        pos.x = target.transform.position.x;
        pos.z = target.transform.position.z;
        pos.y = h;
        transform.position = pos;
    }
}
