using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageClearUI : MonoBehaviour
{
    [Header("ui밝아지는 속도")]
    [SerializeField] float colorSpeed;
    [Header("텍스트 나오는 속도")]
    [SerializeField] float textSpeed;
    [Header("출력할 문자")]
    [SerializeField] string Text;
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
    IEnumerator text()
    {
        Time.timeScale = 0;
        string me = Text;
        foreach (char c in me)
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        yield break;
    }
}
