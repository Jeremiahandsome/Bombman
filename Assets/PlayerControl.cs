using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //ը��Ԥ����
    public GameObject BombPre;
    public float CD = 1;
    private float timer = 0;    //��ʱ��
    public int hp = 1;      //Ѫ��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            return;

        float horizontal = Input.GetAxis("Horizontal");     //��ȡˮƽ��
        float vertical = Input.GetAxis("Vertical");         //��ֱ��
        Vector3 dir = new Vector3(horizontal, 0, vertical);     //��ȡ����

        if(dir!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);//���������ķ���
            transform.position += dir * 2 * Time.deltaTime;     //�ƶ�:ÿ������
            GetComponent<Animator>().SetBool("IsRun", true);     //�ܲ�����
        }
        else
        {
            //վ��
            GetComponent<Animator>().SetBool("IsRun", false);
        }

        timer += Time.deltaTime;

        //���¿ո��������CDʱ�ͷ�ը��
        if(Input.GetKeyDown(KeyCode.Space)&&timer>=CD)
        {
            timer = 0;
            Instantiate(BombPre, transform.position, transform.rotation);   //�ͷ�ը��
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //��������ʱ����
        if(collision.collider.tag=="Enemy")
        {
            hp -=1;
            //GetComponent<Animator>().SetTrigger("Die");
        }
        if(hp==0)
            GetComponent<Animator>().SetTrigger("Die");
    }
}
