
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
    [SerializeField] Sprite MuteImage;
    [SerializeField] Sprite MuteNoImage;
    [SerializeField] Image SoundImage;
    private int ListMaxCount;
    private int ImageCurrentCount = 0;
    private int Count = 0;
    private void Start()
    {
        ListMaxCount = PanelList.Count;
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
        SceneManager.LoadScene(ImageCurrentCount);
    }
    public void LoadMenu()
    {
        audioSource.clip = Manager.manager.Sound.SetSoundSFX(1);
        audioSource.Play();
        StartCoroutine(ShowMenuSequence());
        Invoke("GoMenu", 0.35f);
    }
    public void VolumSetting()
    {
        Count++;
        if (Count % 2 == 0)
        {
            SoundImage.sprite = MuteNoImage;
            Manager.manager.Volume.MuteAll();
        }
        else
        {
            SoundImage.sprite = MuteImage;
            Manager.manager.Volume.MuteNoAll();
        } 

    }
    private void GoMenu() => SceneManager.LoadScene(0);

}
