using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    LineRenderer line;
    public Transform startPoint;
    public Transform endPoint;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        line.SetPosition(0,startPoint.position);
        line.SetPosition(1, endPoint.position);
    }
}
