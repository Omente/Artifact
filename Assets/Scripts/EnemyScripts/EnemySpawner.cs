using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int eaterChance = 3;
    [SerializeField] private float spawnTime = 12f;
    [SerializeField] private float spawnReducion = 1f;
    [SerializeField] private float minimuSpawnDelay = 5f;
    [SerializeField] private GameObject wolfPrefab, wolfEaterPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private float currentSpawnTime;
    private float timer;

    private void Start()
    {
        currentSpawnTime = spawnTime;
        timer = Time.time;
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            Spawn();
            
            currentSpawnTime -= spawnReducion;
            if (currentSpawnTime <= minimuSpawnDelay) currentSpawnTime = minimuSpawnDelay;
            timer = Time.time + currentSpawnTime;
        }
    }

    private void Spawn()
    {
        if(UnityEngine.Random.Range(0,11) > eaterChance)
        {
            Instantiate(wolfPrefab, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
        else
        {
            Instantiate(wolfEaterPrefab, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
