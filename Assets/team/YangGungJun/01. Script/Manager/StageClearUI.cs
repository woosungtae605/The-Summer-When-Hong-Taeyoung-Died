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
    [Header("����� ����")]
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
