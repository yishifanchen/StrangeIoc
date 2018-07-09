using UnityEngine;
using System.Collections;
/// <summary>
/// 无效时间
/// </summary>
public class DeactiveForTime : MonoBehaviour {

    public float delayTime=3;
    void OnEnable()
    {
        Invoke("Deactive", delayTime);
    }
    //失效
    void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
