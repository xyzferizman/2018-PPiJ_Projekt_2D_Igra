using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KretanjeDijamanata : MonoBehaviour {
    public float speed;
    
	// Use this for initialization
	void Start () {
        speed = 40f;
	}
	
	// Update is called once per frame
	void Update () {
        //Text score = GameObject.FindObjectOfType<Text>();
        int br = 0;//Int32.Parse(score.text);
        if (br >= 50  )
        {
            speed += 20f;
        }
        if (br >= 100)
        {
            speed += 10f;
        }
        if (br >= 150)
        {
            speed += 10f;
        }
        if (br >= 350)
        {
            speed += 10f;
        }
        if (br >= 450)
        {
            speed += 10f;
        }
        if (br >= 550)
        {
            speed += 10f;
        }
        Vector2 position0 = transform.position;
        position0 = new Vector2(position0.x - speed * Time.deltaTime, position0.y);
        transform.position = position0;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }
}
