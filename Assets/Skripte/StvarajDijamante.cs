using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StvarajDijamante : MonoBehaviour {
    public GameObject Dijamant; //nas prefab dijamanta
    public GameObject Crni3;
    int maxRateInSec = 5;
    float pocVrijeme;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StvoriDija()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject dija = (GameObject)Instantiate(Dijamant);
        dija.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        NextSpawn();
    }

    void StvoriDijaCrni3()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject crni = (GameObject)Instantiate(Crni3);
        crni.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        NextSpawn();
    }

    void NextSpawn()
    {
        float spawnInSeconds;

        if (maxRateInSec > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxRateInSec);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        if ((int)(pocVrijeme- Time.time) % 10 == 0)
        {
            Invoke("StvoriDijaCrni3", spawnInSeconds);
        } else
        {
            Invoke("StvoriDija", spawnInSeconds);
        }
        
    }

    void Ubrzaj()
    {
        if (maxRateInSec > 1f)
        {
            maxRateInSec--;
        }
        if (maxRateInSec == 1f)
        {
            CancelInvoke("Ubrzaj");
        }
    }
    public void ScheduleDijamantSpawner()
    {
        pocVrijeme = Time.time;//daj pocetno vrijeme
        Invoke("StvoriDija", maxRateInSec);

        InvokeRepeating("Ubrzaj", 0f, 20f);
    }

    public void UnscheduleDijamantSpawner()
    {
        CancelInvoke("StvoriDija");
        CancelInvoke("Ubrzaj");
    }
}
