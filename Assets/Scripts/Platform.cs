using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    Vector3 movement;
    GameObject topline;
    public float Speed;

    void Start()
    {
        movement.y = Speed;
        topline = GameObject.Find("TopLine");
    }
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;

        //达到一定高度后销毁平台
        if(transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
