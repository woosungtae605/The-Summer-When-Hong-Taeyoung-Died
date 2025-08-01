using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [Header("버튼들")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;
    [Header("게임 제목")]
    [SerializeField] private TextMeshProUGUI GameName;

    [Header("UI 오브젝트")]
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Menu;

    [Header("애니메이션 설정")]
    [SerializeField] private float buttonMoveDistance = 500f;
    [SerializeField] private float buttonMoveTime = 0.5f;
    [SerializeField] private float panelMoveTime = 0.87f;
    [SerializeField] private Vector3 panelOutPosition = new Vector3(-1500f, 0, 0);
    [SerializeField] private float PanelPos;
    [SerializeField] Canvas canvas;

    [SerializeField] AudioSource audioSource;

    private Vector3 GameTextOriginPos;
    private Vector3 startButtonOriginPos;
    private Vector3 menuButtonOriginPos;
    private Vector3 exitButtonOriginPos;

    private void Start()
    {
        GameTextOriginPos = GameName.transform.position;
        startButtonOriginPos = startButton.transform.position;
        menuButtonOriginPos = menuButton.transform.position;
        exitButtonOriginPos = exitButton.transform.position;
        DontDestroyOnLoad(canvas);
        MoveButtons();
    }

    private void MoveButtons()
    {
        GameName.transform.DOMoveX(GameName.transform.position.x + buttonMoveDistance, buttonMoveTime);
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
        StartCoroutine(ShowMenuSequence());
        Invoke("GoStage1", 0.35f);
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

}
