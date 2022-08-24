using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private PlayerControl player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();    //获取玩家
    }

    
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);//玩家与敌人之间的距离
        
        //3m之内且玩家存活
        if(dis<3&&player.hp>0)
        {
            transform.LookAt(player.transform);     //转向玩家
            transform.Translate(Vector3.forward * 1.8f * Time.deltaTime);  //朝玩家移动
            GetComponent<Animator>().SetBool("IsRun", true);    //播放移动动画
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRun", false);   //站立
        }
    }

    //受到攻击
    public void GetHit()
    {
        Destroy(gameObject);
    }
}
