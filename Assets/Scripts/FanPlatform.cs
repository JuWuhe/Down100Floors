using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour
{

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //发生碰撞时 播放run动画
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("FanPlatform_run");
        }
    }
}
