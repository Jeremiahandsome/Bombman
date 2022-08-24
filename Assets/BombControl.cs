using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public GameObject BoomEffect;   //��ըЧ��Ԥ����
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //2�뱬ը
        if(timer>2)
        {
            Instantiate(BoomEffect, transform.position, transform.rotation);    //������ըЧ��
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);   //��ȡ���׷�Χ�ڵ���ײ��

            //������ײ��
            foreach(Collider collider in colliders)
            {
                //�Ե�������˺�
                if(collider.tag=="Enemy")
                {
                    collider.GetComponent<EnemyControl>().GetHit();
                }
            }
            Destroy(gameObject);
        }
    }
}
