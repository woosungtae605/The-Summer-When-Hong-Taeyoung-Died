using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class StartUI : MonoBehaviour
{
    [Header("버튼들")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;

    [Header("UI 오브젝트")]
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Menu;

    [Header("애니메이션 설정")]
    [SerializeField] private float buttonMoveDistance = 500f;
    [SerializeField] private float buttonMoveTime = 0.5f;
    [SerializeField] private float panelMoveTime = 0.87f;
    [SerializeField] private Vector3 panelOutPosition = new Vector3(-1500f, 0, 0);
    [SerializeField] private Vector3 panelResetPosition = new Vector3(-200f, 0, 0);

    private Vector3 startButtonOriginPos;
    private Vector3 menuButtonOriginPos;
    private Vector3 exitButtonOriginPos;

    private void Start()
    {
        startButtonOriginPos = startButton.transform.position;
        menuButtonOriginPos = menuButton.transform.position;
        exitButtonOriginPos = exitButton.transform.position;
        MoveButtons();
    }

    private void MoveButtons()
    {
        startButton.transform.DOMoveX(startButton.transform.position.x + buttonMoveDistance, buttonMoveTime);
        menuButton.transform.DOMoveX(menuButton.transform.position.x + buttonMoveDistance, buttonMoveTime + 0.3f);
        exitButton.transform.DOMoveX(exitButton.transform.position.x + buttonMoveDistance, buttonMoveTime + 0.5f);
    }
    private void MoveButtonsReset()
    {
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

        Vector3 target = new Vector3(panelOutPosition.x, Panel.transform.position.y, 0);
        Panel.transform.DOMove(target, panelMoveTime);
    }

    private void ResetPanelPosition()
    {
        RectTransform rect = Panel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(2400, rect.anchoredPosition.y);
    }

    public void QuitGame() => Application.Quit();

}
