using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    //控制随机生成间隔时间
    public float spawnTime; 
    public float countTime;

    private Vector3 spawnPosition;

    int spikeNum = 0;
    
    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3f, 3f);  //具体数值具体调整

        if(countTime >= spawnTime)
        {
            CreatPlatform();
            countTime = 0;
        }

    }

    public void CreatPlatform()
    {
        int index = Random.Range(0, platforms.Count);
        if(index == 4)
        {
            spikeNum++;
        }
        if(spikeNum > 1)
        {
            spikeNum = 0;
            countTime = spawnTime;
            return;
        }
        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
}
