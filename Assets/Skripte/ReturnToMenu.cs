using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {

    public void LoadMenu()
    {
        // pretpostavka : Menu ce imati buildIndex = 0
        SceneManager.LoadScene(0);
    }
}
