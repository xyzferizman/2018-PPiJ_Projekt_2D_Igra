using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

// ova skripta treba biti attachana za HighScore objekt
public class LoadHighScoreData : MonoBehaviour  {

    public Text[] nickArray;
    public Text[] scoreArray;
    
    void Start()
    {
        Debug.Log("ucitavam podatke iz baze");

        string connectionString = "URI=file:D:/igra2D_audio_i_animacije/Assets/Plugins/baza.s3db"; //Path to database.

        IDbConnection dbconn;
        
        // uklonio "redundant" cast (IDbConnection)
        //dbconn = new SqliteConnection(connectionString);
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT nickname,score FROM bazaPodataka ORDER BY score DESC LIMIT 5";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            int iterator = 0;

            while (reader.Read())
            {
                try
                {
                    //if (iterator == 5) break;

                    string nickname = reader.GetString(0);
                    int score = reader.GetInt32(1);

                    Debug.Log("nickname : " + nickname + " ,score = " + score);

                    nickArray[iterator].text = nickname;
                    scoreArray[iterator].text = score.ToString();

                    iterator++;
                }
                catch ( NullReferenceException e)
                {
                    //Debug.Log(e.Message);
                    //Debug.Log("iterator je:" + iterator);
                }
                
            }

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            //dbconn.Close();
           // dbconn = null;
        }
        
    }
}

