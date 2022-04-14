using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlanetControllerGO : MonoBehaviour {

    public GameObject[] Planets;//polje planetGO prefaba

    //red planeta
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);
        availablePlanets.Enqueue(Planets[3]);

        //pozovi MovePlanetLeft svakih x sekundi
        InvokeRepeating("MovePlanetLeft",0,20f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //funkcija za pustanje planeta koja smjesta isMoving zastavicu kao istinitom
    void MovePlanetLeft()
    {
        EnqueuePlanets();
        if(availablePlanets.Count == 0)
        {
            return;
        }

        //izvadi iz reda planet
        GameObject aPlanet = availablePlanets.Dequeue();

        //zastavica = istina
        aPlanet.GetComponent<Planet>().isMoving = true;

    }

    //
    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            //ako planet odlazi iz ekrana onda se planet ne mice
            if((aPlanet.transform.position.x < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                //resetiraj poziciju planete
                aPlanet.GetComponent<Planet>().ResetPosition();
                //enqueue planetu
                availablePlanets.Enqueue(aPlanet); 
            }
        }
    }
}
