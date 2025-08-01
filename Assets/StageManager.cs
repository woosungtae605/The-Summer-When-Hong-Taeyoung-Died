
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public List<GameObject> PanelList = new();
    public List<GameObject> GameMap = new();
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject Panel;
    [SerializeField] private float panelMoveTime = 0.87f;
    [SerializeField] private Vector3 panelOutPosition = new Vector3(-1500f, 0, 0);
    [SerializeField] private float PanelPos;
    private int ListMaxCount;
    private int ImageCurrentCount = 0;
    private void Start()
    {
        ListMaxCount = PanelList.Count;
        Manager.manager.BGM.SetBGM(1);
        CamaraControll.camaraControl.SetCamaraSize(5);
        audioSource.clip = Manager.manager.Sound.SetSoundSFX(0);
    }
    public void NextPoint()
    {

        if (ImageCurrentCount < ListMaxCount - 1)
        {

            ImageCurrentCount++;
            updateUI();
            UpdateMap();
        }
    }

    private IEnumerator ShowMenuSequence()
    {
        PlayCutSceneOut();

        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(panelMoveTime - 0.5f);
        ResetPanelPosition();

    }

    private IEnumerator HideMenuSequence()
    {
        PlayCutSceneOut();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(panelMoveTime - 0.5f);
        ResetPanelPosition();
    }

    private void PlayCutSceneOut()
    {
        Vector3 target = new Vector3(panelOutPosition.x, Panel.transform.position.y, 0);
        Panel.transform.DOMove(target, panelMoveTime);
    }

    private void ResetPanelPosition()
    {
        RectTransform rect = Panel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(PanelPos, rect.anchoredPosition.y);
    }

    public void QuitGame() => Application.Quit();
    public void DownPoint()
    {
        if (ImageCurrentCount > 0)
        {

            ImageCurrentCount--;
            updateUI();
            UpdateMap();
        }
    }

    private void updateUI()
    {

        audioSource.Play();
        for (int i = 0; i < PanelList.Count; i++)
        {
            PanelList[i].SetActive(ImageCurrentCount == i);
        }
    }
    private void UpdateMap()
    {
        for (int i = 0; i < PanelList.Count; i++)
        {
            GameMap[i].SetActive(ImageCurrentCount == i);
        }
    }

    public void LoadScene()
    {
        if (ImageCurrentCount == 0)
        {
            SceneManager.LoadScene(2);
        }
        else if (ImageCurrentCount == 1)
        {
            SceneManager.LoadScene(3);
        }
        else if (ImageCurrentCount == 2)
        {
            SceneManager.LoadScene(4);
        }
        else if (ImageCurrentCount == 3)
        {
            SceneManager.LoadScene(5);
        }
        else if (ImageCurrentCount == 4)
        {
            SceneManager.LoadScene(6);
        }
    }
    public void LoadMenu()
    {
        audioSource.clip = Manager.manager.Sound.SetSoundSFX(1);
        audioSource.Play();
        StartCoroutine(ShowMenuSequence());
        Invoke("GoMenu", 0.35f);
    }

    private void GoMenu() => SceneManager.LoadScene(0);

}
