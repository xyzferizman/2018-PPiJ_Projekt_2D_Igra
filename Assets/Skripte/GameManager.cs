using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject stvarajDijamante;
    public GameObject GameOverGO;
    public GameObject highScore;
    public GameObject inputField;
    public GameObject submitButton;
    public Text nickname;
    public Text score;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;
	// Use this for initialization
	void Start () {
        GMState = GameManagerState.Opening;
	}
	
	void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                highScore.SetActive(false);
                playButton.SetActive(true);
                inputField.SetActive(false);
                submitButton.SetActive(false);
                break;

            case GameManagerState.Gameplay:
                playButton.SetActive(false);

                playerShip.GetComponent<IgraceKontrole>().Init();

                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                stvarajDijamante.GetComponent<StvarajDijamante>().ScheduleDijamantSpawner();


                break;
                 
            case GameManagerState.GameOver:
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                stvarajDijamante.GetComponent<StvarajDijamante>().UnscheduleDijamantSpawner();
                inputField.SetActive(true);
                submitButton.SetActive(true);
                highScore.SetActive(true);
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 10f);
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void HighScoreShow()
    {
        SceneManager.LoadScene(1);

    }
    // ova metoda se zove nakon pritiska na tipku 
    public void Spremi_Nick_i_Score_u_Database()
    {

        string conn = "URI=file:" + Application.dataPath + "/Plugins/baza.s3db";

        //IDbConnection dbconn;

        //dbconn = (IDbConnection)new SqliteConnection(conn);
        using (IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn))
        {
            dbconn.Open();

            // dakle ovdje trebaš stavit podatke iz igre , tj "pravi" nickname i score
            string nick = nickname.text;
            int highscore = Int32.Parse(score.text);

            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlInsert = "INSERT INTO bazaPodataka (nickname,score) VALUES(@param1,@param2);";
            dbcmd.CommandText = sqlInsert;

            dbcmd.Parameters.Add(new SqliteParameter("@param1", nick));
            dbcmd.Parameters.Add(new SqliteParameter("@param2", highscore));

            //Debug.Log("ubacio podatak");

            dbcmd.ExecuteNonQuery();

            dbcmd.Dispose();
            dbcmd = null;
            //dbconn.Close();
            //dbconn = null;

            // kad se završio transfer podataka , onda load pocetnu scenu (igru)
            SceneManager.LoadScene(1);
        }
        

    }
}
