using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public float speed;//brzina planeta
    public bool isMoving;//zastavica za pomicanje planeta lijevo

    Vector2 min;//donja lijeva tocka ekrana
    Vector2 max;//gornja desna tocka ekrana
    void Awake()
    {
        isMoving = false;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //dodaj planet na polovici visine do max x
        max.x = max.x + GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        
        //oduzmi planeti pola visine do min x
        min.x = min.x - GetComponent<SpriteRenderer>().sprite.bounds.extents.x;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMoving)
            return;
        //trenutna pozicija planeta
        Vector2 position = transform.position;

        //nova pozicija planeta
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        //azuriraj poziciju
        transform.position = position;

        //ako planet dode do minimuma x, zaustavi pomicanje
            if (transform.position.x +25 < min.x)
                isMoving = false;
   

	}

       public void ResetPosition()
    {
        //ponovi poziciju planet na random y i max x
        transform.position = new Vector2(max.x+25, Random.Range(min.y, max.y));

    }
}
