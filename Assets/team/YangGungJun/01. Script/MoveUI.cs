using UnityEngine;
using DG.Tweening;
public class MoveUI : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    private void Start()
    {
        Panel.transform.DOMove(new Vector2(Panel.transform.position.x, Panel.transform.position.y + 100),20);
    }
}
