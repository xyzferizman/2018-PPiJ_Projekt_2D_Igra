using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadHighScore : MonoBehaviour  {
       
    public void LoadHighScoreGUI()
    {
        // ucitaj highscore
        int buildIndexOfHighScore = 1234;

        SceneManager.LoadScene(buildIndexOfHighScore);
    }

}

