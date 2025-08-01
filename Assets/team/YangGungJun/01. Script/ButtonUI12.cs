using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUI12 : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI Starttext;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Starttext.transform.DOScale(2f, 0.2f).SetEase(Ease.OutBack);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Starttext.transform.DOScale(1, 0.2f).SetEase(Ease.OutBack);
    }
}
