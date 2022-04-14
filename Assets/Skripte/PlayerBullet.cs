using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    float speed;
	void Start () {
        speed = 45f;
        FindObjectOfType<AudioManager>().Sviraj("JaPucam");
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Neprijatelj" )
        {
            Destroy(gameObject);//ovdje ubijamo lika ,ali treba staviti da se zivot oduzme
        }
    }
}
