using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    [SerializeField] private GameObject butlletPrefabs;
    [SerializeField] private float TimeSpawn;
    [SerializeField] private float SpawnTime;

    [SerializeField] private Transform Pointbullet;
    void Start()
    {
        TimeSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpawn -= Time.deltaTime;
        if(TimeSpawn <= 0)
        {
            SpawnBullet();
            TimeSpawn = SpawnTime;
        }
    }
    private void SpawnBullet()
    {
        //  Instantiate(butlletPrefabs, Pointbullet.position, quaternion.identity);
        GameObject bullet = PollingObject.SharedInstance.GetPooledObject();
        if(bullet!= null)
        {
            bullet.transform.position= Pointbullet.position;
            bullet.SetActive(true);
        }
    }
}
