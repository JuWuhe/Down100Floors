using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBG : MonoBehaviour
{
    Material material;
    Vector2 movement;

    public Vector2 speed;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        movement += speed * Time.deltaTime;
        material.mainTextureOffset = movement;
    }
}
