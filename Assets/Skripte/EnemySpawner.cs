using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyGO;

    float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(max.x, Random.Range(min.y,max.y));

        NextSpawn();

    }

    void NextSpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnInSeconds);
    }
    
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
