using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //炸弹预设体
    public GameObject BombPre;
    public float CD = 1;
    private float timer = 0;    //计时器
    public int hp = 1;      //血量
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            return;

        float horizontal = Input.GetAxis("Horizontal");     //获取水平轴
        float vertical = Input.GetAxis("Vertical");         //垂直轴
        Vector3 dir = new Vector3(horizontal, 0, vertical);     //获取向量

        if(dir!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);//朝向向量的方向
            transform.position += dir * 2 * Time.deltaTime;     //移动:每秒两米
            GetComponent<Animator>().SetBool("IsRun", true);     //跑步动画
        }
        else
        {
            //站立
            GetComponent<Animator>().SetBool("IsRun", false);
        }

        timer += Time.deltaTime;

        //按下空格键且满足CD时释放炸弹
        if(Input.GetKeyDown(KeyCode.Space)&&timer>=CD)
        {
            timer = 0;
            Instantiate(BombPre, transform.position, transform.rotation);   //释放炸弹
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //碰到敌人时死亡
        if(collision.collider.tag=="Enemy")
        {
            hp -=1;
            //GetComponent<Animator>().SetTrigger("Die");
        }
        if(hp==0)
            GetComponent<Animator>().SetTrigger("Die");
    }
}
