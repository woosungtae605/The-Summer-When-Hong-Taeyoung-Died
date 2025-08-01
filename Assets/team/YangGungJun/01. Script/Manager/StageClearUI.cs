using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageClearUI : MonoBehaviour
{
    [Header("ui������� �ӵ�")]
    [SerializeField] float colorSpeed;
    [Header("�ؽ�Ʈ ������ �ӵ�")]
    [SerializeField] float textSpeed;
    [Header(" �й�� ����� ����")]
    [SerializeField] string TextWin;
    [SerializeField] string TextLose;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void OnDisable()
    {
        image.color = new Color(0, 0, 0, 0);
    }
    private void Update()
    {
        colorSpeed = Mathf.Clamp01(colorSpeed);
        image.color += new Color(0, 0, 0, colorSpeed);
    }
    public void PrintText(bool win)
    {
        if (win)
        {
            gameObject.SetActive(true); 
            StartCoroutine(textWinText());
            
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(textLoseText());
        }
    }
    IEnumerator textLoseText()
    {
        Time.timeScale = 0;
        string me = TextWin;
        foreach (char c in me)
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        yield break;
    }
    IEnumerator textWinText()
    {
        Time.timeScale = 0;
        string me = TextLose;
        foreach (char c in me)
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        yield break;
    }
}
