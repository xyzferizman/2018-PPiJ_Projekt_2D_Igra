using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IgraceKontrole : MonoBehaviour {

    public float speed;
    public GameObject Boom;
    public Text zivoti;
    int brZivota;
    /*public KeyCode gore;
    public KeyCode dolje;
    public Rigidbody2D tijelo;*/
    bool zid = false;

    const int MaxLives = 5;

    public GameObject GameManagerGO;
    public GameObject PlayerBulletGO;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;


    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);

        /*
        if (Input.GetKey(gore))
        {
            tijelo.velocity = new Vector2(0, (speed + 2) * Time.deltaTime);
        } else if (Input.GetKey(dolje))
        {
            tijelo.velocity = new Vector2(0, (-speed - 5) * Time.deltaTime);
        } else
        {
            tijelo.velocity = new Vector2(0, 0);
        }*/


    }

    public void Init()
    {
        brZivota = MaxLives;
        zivoti.text = brZivota.ToString();

        gameObject.SetActive(true);
    }

    public void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 7.5f;
        min.x = min.x + 7.5f;

        max.y = max.y - 7.5f;
        min.y = min.y + 7.5f;

        //trenutna pozicija igraca
        Vector2 poz = transform.position;
        //nova pozicija
        poz += direction * speed * Time.deltaTime;

        poz.x = Mathf.Clamp(poz.x, min.x, max.x);
        poz.y = Mathf.Clamp(poz.y, min.y, max.y);

        //postavi novu poziciju igraca
        transform.position = poz;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Neprijatelj" || collision.tag == "NeprijateljMetak")
        {
            StvoriBoom();
            FindObjectOfType<AudioManager>().Sviraj("Explo");
            brZivota = Int32.Parse(zivoti.text);
            brZivota--;
            if(brZivota == 0)
            {
                zivoti.text = brZivota.ToString();
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
            zivoti.text = brZivota.ToString();
            //Destroy(gameObject);//ovdje ubijamo lika ,ali treba staviti da se zivot oduzme
        }
    }

    void StvoriBoom()
    {
        GameObject expl = (GameObject)Instantiate(Boom);
        //pozicija eksplozije di se nalazi igrac
        expl.transform.position = transform.position;
    }
}
