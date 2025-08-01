using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] float CurretTime;
    [SerializeField] float MaxTime;
    [SerializeField] TextMeshProUGUI WaveText;
    [SerializeField] GameObject GameEndUI;
    private AudioSource audioSource;
    int count = 0;
    private void Start()
    {
        audioSource.clip = Manager.manager.Sound.SetSoundBGM(3);
        SetText();
    }
    private void Update()
    {
        CurretTime += Time.deltaTime;
        if (CurretTime >= MaxTime)
        {
            SetText();
            CurretTime = 0;
        }
    }
    public void OpenGameEndUI()
    {
        GameEndUI.SetActive(true);
    }
    public void SetText()
    {
        count++;
       // WaveText.text = $"{count}Wave";
    }
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
