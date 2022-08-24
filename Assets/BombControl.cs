using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public GameObject BoomEffect;   //爆炸效果预设体
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //2秒爆炸
        if(timer>2)
        {
            Instantiate(BoomEffect, transform.position, transform.rotation);    //产生爆炸效果
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);   //获取两米范围内的碰撞体

            //遍历碰撞体
            foreach(Collider collider in colliders)
            {
                //对敌人造成伤害
                if(collider.tag=="Enemy")
                {
                    collider.GetComponent<EnemyControl>().GetHit();
                }
            }
            Destroy(gameObject);
        }
    }
}
