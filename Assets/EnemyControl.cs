using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private PlayerControl player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();    //��ȡ���
    }

    
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);//��������֮��ľ���
        
        //3m֮������Ҵ��
        if(dis<3&&player.hp>0)
        {
            transform.LookAt(player.transform);     //ת�����
            transform.Translate(Vector3.forward * 1.8f * Time.deltaTime);  //������ƶ�
            GetComponent<Animator>().SetBool("IsRun", true);    //�����ƶ�����
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRun", false);   //վ��
        }
    }

    //�ܵ�����
    public void GetHit()
    {
        Destroy(gameObject);
    }
}
