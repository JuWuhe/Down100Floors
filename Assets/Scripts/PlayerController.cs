using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    float xVelocity;

    public bool isOnGround;
    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;

    bool playerDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius,platform); //站地检测
        anim.SetBool("isOnGround", isOnGround);

        Movement();
    }

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal"); //读取

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y); //移动游戏角色

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //跑动动画


        if (xVelocity != 0) //如果等于0 角色会消失看不见
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);//调整角色朝向
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //弹跳平台
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision) //触碰尖刺检测
    {
        if (collision.CompareTag("Spike"))
        {
            anim.SetTrigger("Dead");
        }
    }

    public void PlayerDead() //角色死亡事件
    {
        playerDead = true;
        GameManager.GameOver(playerDead);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        //如果使用DrawSphere则是实心的
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}
