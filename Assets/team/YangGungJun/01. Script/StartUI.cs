using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;

public class StartUI : MonoBehaviour
{
    [Header("버튼들")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;
    [Header("게임 제목")]
    [SerializeField] private TextMeshProUGUI GameName;
    [SerializeField] private TextMeshProUGUI TutorielCount;

    [Header("UI 오브젝트")]
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject tutoriel;
    [SerializeField] private GameObject OnecreditsObject;
    [SerializeField] private GameObject creditsObject;

    [Header("애니메이션 설정")]
    [SerializeField] private float NameDistance;
    [SerializeField] private float buttonMoveDistance = 500f;
    [SerializeField] private float buttonMoveTime = 0.5f;
    [SerializeField] private float panelMoveTime = 0.87f;
    [SerializeField] private Vector3 panelOutPosition = new Vector3(-1500f, 0, 0);
    [SerializeField] private float PanelPos;

    [SerializeField] AudioSource audioSource;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;

    private Vector3 GameTextOriginPos;
    private Vector3 startButtonOriginPos;
    private Vector3 menuButtonOriginPos;
    private Vector3 exitButtonOriginPos;
    private Vector3 creditsOriginPos;

    private int CurrunetCount = 0;
    private bool OnTutoriel = false;
    public List<Image> ImageList = new();

    private void Awake()
    {
        VolumeManager volumeManager = FindObjectOfType<VolumeManager>();
        if (volumeManager != null)
        {
            volumeManager.SetSliders(masterSlider, sfxSlider, bgmSlider);
        }
        else
        {
            Debug.LogWarning("VolumeManager 인스턴스를 찾을 수 없습니다.");
        }
    }
    private void Start()
    {

        GameTextOriginPos = GameName.transform.position;
        startButtonOriginPos = startButton.transform.position;
        menuButtonOriginPos = menuButton.transform.position;
        exitButtonOriginPos = exitButton.transform.position;
        creditsOriginPos = creditsObject.transform.position;
        Manager.manager.BGM.SetBGM(0);
        MoveButtons();
    }
    private void MoveButtons()
    {
        GameName.transform.DOMoveX(GameName.transform.position.x + NameDistance, buttonMoveTime);
        startButton.transform.DOMoveX(startButton.transform.position.x + buttonMoveDistance, buttonMoveTime);
        menuButton.transform.DOMoveX(menuButton.transform.position.x + buttonMoveDistance, buttonMoveTime + 0.3f);
        exitButton.transform.DOMoveX(exitButton.transform.position.x + buttonMoveDistance, buttonMoveTime + 0.5f);
    }
    private void MoveButtonsReset()
    {
        GameName.transform.position = GameTextOriginPos;
        startButton.transform.position = startButtonOriginPos;
        menuButton.transform.position = menuButtonOriginPos;
        exitButton.transform.position = exitButtonOriginPos;
    }

    public void MenuMove()
    {
        StartCoroutine(ShowMenuSequence());
    }

    public void MenuNoMove()
    {
        StartCoroutine(HideMenuSequence());
    }
    public void StartButton()
    {
        if (!OnTutoriel)
        {
            StartCoroutine(ShowMenuSequence());
            Invoke("GoStage1", 0.35f);
        }

    }
    public void GoStage1()
    {
        SceneManager.LoadScene(1);
    }
    private IEnumerator ShowMenuSequence()
    {
        PlayCutSceneOut();

        yield return new WaitForSeconds(0.5f);
        MoveButtonsReset();
        SetButtonsActive(false);

        yield return new WaitForSeconds(panelMoveTime - 0.5f);
        ResetPanelPosition();
        Menu.SetActive(true);
    }

    private IEnumerator HideMenuSequence()
    {
        PlayCutSceneOut();

        yield return new WaitForSeconds(0.5f);
        Menu.SetActive(false);

        yield return new WaitForSeconds(panelMoveTime - 0.5f);
        MoveButtons();
        ResetPanelPosition();
        SetButtonsActive(true);
    }

    private void SetButtonsActive(bool isActive)
    {
        startButton.gameObject.SetActive(isActive);
        menuButton.gameObject.SetActive(isActive);
        exitButton.gameObject.SetActive(isActive);
    }

    private void PlayCutSceneOut()
    {
        audioSource.clip = Manager.manager.Sound.SetSoundSFX(1);
        audioSource.Play();
        Vector3 target = new Vector3(panelOutPosition.x, Panel.transform.position.y, 0);
        Panel.transform.DOMove(target, panelMoveTime);
    }

    private void ResetPanelPosition()
    {
        RectTransform rect = Panel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(PanelPos, rect.anchoredPosition.y);
    }

    public void QuitGame() => Application.Quit();
    public void TutoralNext()
    {
        if (CurrunetCount < ImageList.Count - 1)
        {
            CurrunetCount++;
            List();
        }

    }
    public void TutoralDown()
    {
        if (CurrunetCount > 0)
        {
            CurrunetCount--;
            List();
        }

    }
    public void SetTutorial()
    {

        List();
        tutoriel.SetActive(true);
    }
    public void UnSetTutorial()
    {

        ListUn();
        tutoriel.SetActive(false);
    }
    private void List()
    {
        TutorielCount.text = $"{CurrunetCount + 1}/{ImageList.Count}"; // 1부터 표시

        for (int i = 0; i < ImageList.Count; i++)
        {
            ImageList[i].gameObject.SetActive(CurrunetCount == i);
        }
    }
    public void credits()
    {
        creditsObject.transform.DOKill();
        creditsObject.transform.position = creditsOriginPos;
        Manager.manager.BGM.SetBGM(2);
        OnecreditsObject.SetActive(true);
        creditsObject.transform.DOMoveY(creditsOriginPos.y + 3000, 30);
    }
    public void Returncredits()
    {
        Manager.manager.BGM.SetBGM(0);
        creditsObject.transform.DOKill();
        creditsObject.transform.position = creditsOriginPos; 
        OnecreditsObject.SetActive(false); 
    }
    private void ListUn()
    {
        foreach (var item in ImageList)
        {
            item.gameObject.SetActive(false);
        }
    }

}
