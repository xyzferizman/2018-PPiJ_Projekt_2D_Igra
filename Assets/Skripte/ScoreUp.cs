using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreUp : MonoBehaviour {

    public Text score;
    int broj = 0;
    bool crveni = false;
    bool crni3 = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CrveniDijamant")
        {
            Debug.Log("sudar se desio");

            crveni = true;
        }
        if (collision.tag == "CrniDijamant")
        {
            Debug.Log("sudar se desio");

            crni3 = true;
        }
    }

    // Update is called once per frame
    void Update () {
        
        if(crveni)
        {
            broj = Int32.Parse(score.text) + 10;
            crveni=false;
        }

        if (crni3)
        {
            broj = Int32.Parse(score.text) + 45;
            crni3 = false;
        }

        score.text = broj.ToString();

    }
}
