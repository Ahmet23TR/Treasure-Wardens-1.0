using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy; 
    [SerializeField] [Range(0, 50)] int PoolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float SpawnTime = 1f;
    GameObject[] pool;

    void Awake() {
        PopulatPool();
    }


    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    void PopulatPool()
    {
        pool = new GameObject[PoolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(Enemy, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
            
        }
    }
    

    IEnumerator CreateEnemy()
   {
        while (true)
        {  
            EnableObjectInPool();
            yield return new WaitForSeconds(1f); 
        }

        
   }
}
