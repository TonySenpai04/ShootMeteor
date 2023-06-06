using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    //[SerializeField] private Transform target;
    [SerializeField] private float TimeSpawn;
    [SerializeField] private float SpawnTime;
    void Start()
    {
        TimeSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpawn -= Time.deltaTime;
        if (TimeSpawn <= 0 && GameControllerUI.Instance.isOver==false)
        {
            SpawnBullet();
            TimeSpawn = SpawnTime;
        }
    }
    private void SpawnBullet()
    {
        
        GameObject bullet = PollingObjectEnemy.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
           Vector2 newPoint = new Vector2(Random.Range(-8.9f, 9), 14.4f);
            bullet.transform.position = newPoint;
            bullet.SetActive(true);
        }
    }
    
}
