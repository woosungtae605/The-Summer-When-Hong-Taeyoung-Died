using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void ReStartGame()
    {
        int NowScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(NowScene);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
