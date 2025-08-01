using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI WaveText;
    [SerializeField] int CamaraSize;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int PlayBgmNumber;
    private void Start()
    {
        Manager.manager.BGM.SetBGM(PlayBgmNumber);
        CamaraControll.camaraControl.SetCamaraSize(CamaraSize);
    }



    public void ReStartGame()
    {
        int NowScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(NowScene);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
