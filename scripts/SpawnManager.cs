using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectSpawn;
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] private Transform[] spawnTransform;
    private float  nextSpawnTime= 0f;
    private TimeManager timeManager;
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > nextSpawnTime && !timeManager.gameOver && !timeManager.gameFinished)
        {
            nextSpawnTime += spawnTime;
            CreateObject(ObjectSpawn[Random.Range(0,ObjectSpawn.Length)], spawnTransform[RandomSpawnNumber()]);
        }
    }
    private void CreateObject(GameObject other,Transform newTransform)
    {
        Instantiate(other, newTransform.position,newTransform.rotation); // belirli konumda verilen objeyi üretir.
    } 
    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnTransform.Length); // 0 dan girilen sayýya kadar üretir.
    }
    
}
