using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbiCrni : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Igrac")
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 pozicija = transform.position;
        if(pozicija.x < min.x || pozicija.y < min.y)
        {
            Destroy(gameObject);
        }
    }


}
