using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    public GameObject StarGO;
    public int MaxStars;


    Color[] starColors =
    {
        new Color(0.9f, 0.95f, 1f),//plavkasta
        new Color(1f, 0.9f, 0.9f),//skoro pa roza
        new Color(1f, 1f, 0.95f),//stvarno ne znam boje
        new Color(1f, 1f, 0.8f),//zuckasta zelenkasta boja
    };
	// Use this for initialization
	void Start () {

        //donja lijeva tocka ekrana
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //gornja desna tocka ekrana
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //petlja za stvaranje zvijezda
        for(int i = 0; i<MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(StarGO);

            //boja zvijezde
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //pozicija zvijezde
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            
            //random brzina zvijezde
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            //zvijezda je podredena StarGeneratorGO-u
            star.transform.parent = transform;
           
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
