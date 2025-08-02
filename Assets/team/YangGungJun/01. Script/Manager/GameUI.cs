using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI WaveText;
    [SerializeField] TextMeshProUGUI GoldText;
    [SerializeField] TextMeshProUGUI HpText;
    [SerializeField] int CamaraSize;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int PlayBgmNumber;
    [SerializeField] GoldChannelSO channelSO;
    [SerializeField] Home home;
    private void Start()
    {
        channelSO.SetGold();
        Manager.manager.BGM.SetBGM(PlayBgmNumber);
        CamaraControll.camaraControl.SetCamaraSize(CamaraSize);
    }

    private void Update()
    {
        GoldText.text = channelSO.Gold.ToString();
        HpText.text = home.Hp.ToString();
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
