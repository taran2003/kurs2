using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemyAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 5f;
    private int waveIndex = 0;
    public GameManager gameManager;

    public Text waveCountDownText;

    void Update()
    {

        if(EnemyAlive>0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }
    }

   IEnumerator  SpawnWave()
   {
       
        PlayrStats.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i =0;i<wave.count;i++)
        {
            if (wave.enemy != null)SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        for (int i = 0; i < wave.fastCount; i++)
        {
            if (wave.fastEnemy != null) SpawnEnemy(wave.fastEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        for (int i = 0; i < wave.fatCount; i++)
        {
            if (wave.fatEnemy != null) SpawnEnemy(wave.fatEnemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemyAlive++;
    }
}
