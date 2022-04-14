using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;

public class nekaSkripta : MonoBehaviour
{

    // kad igrač umre , treba se ovo pozvati
    void Prikazi_END_GUI()
    {
        // treba biti prostor za unos , i tipka za potvrdu nicknamea		

        GameObject endGUI;  // dakle treba ti referenca na npr.Panel koji sadrži InputField i Button , može i drukčija izvedba	

        // setActive(true) za GameObject ili enabled=true za Button,Text,InputField itd. bi trebali riješit stvar 
    //    endGUI.SetActive(true);

        // kad se stisne confirm button , treba se pozvati donja metoda
    }

    // ova metoda se zove nakon pritiska na tipku 
    void Spremi_Nick_i_Score_u_Database()
    {

        string conn = "URI=file:" + Application.dataPath + "/Plugins/ppij_database.s3db";

        IDbConnection dbconn;

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        // dakle ovdje trebaš stavit podatke iz igre , tj "pravi" nickname i score
        string nickname = "TESTNI NICK";
        int score = 6666;

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlInsert = "INSERT INTO GamePlayed (nickname,score) VALUES(@param1,@param2);";
        dbcmd.CommandText = sqlInsert;

        dbcmd.Parameters.Add(new SqliteParameter("@param1", nickname));
        dbcmd.Parameters.Add(new SqliteParameter("@param2", score));

        //Debug.Log("ubacio podatak");

        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        // kad se završio transfer podataka , onda load pocetnu scenu (igru)
        SceneManager.LoadScene(0);

    }
}



