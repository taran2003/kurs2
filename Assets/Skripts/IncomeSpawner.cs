using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeSpawner : MonoBehaviour
{
    public Transform incomePrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 1;
    private float countdown = 2;
    private int waveIndex = 1;



    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;       
    }

    IEnumerator SpawnWave()
    {
       
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(incomePrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public void UpgradeIncome()
    {
       
        if (PlayrStats.money < 10)
        {
            Debug.Log("NOT ENOUGH OXYGEN");
            return;
        }
        PlayrStats.money -= 10;
        waveIndex++;
    }


}
