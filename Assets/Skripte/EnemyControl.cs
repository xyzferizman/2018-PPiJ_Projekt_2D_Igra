using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    float speed;
    public GameObject Boom;
	// Use this for initialization
	void Start () {
        speed = 20f;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Igrac" || collision.tag == "MojMetak")
        {
            StvoriBoom();
            FindObjectOfType<AudioManager>().Sviraj("Explo");
            Destroy(gameObject);//ovdje ubijamo lika 
        }
    }

    void StvoriBoom()
    {
        GameObject expl = (GameObject)Instantiate(Boom);
        //pozicija eksplozije di se nalazi igrac
        expl.transform.position = transform.position;
    }
}
