using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] float CurretTime;
    [SerializeField] float MaxTime;
    [SerializeField] TextMeshProUGUI WaveText;
    int count = 0;
    private void Start()
    {
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
    public void SetText()
    {
        count++;
        WaveText.text = $"{count}Wave";
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
