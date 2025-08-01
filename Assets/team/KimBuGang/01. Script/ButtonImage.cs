using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImage : MonoBehaviour
{
    public int index;
    public TowerStats tower;
    private Image image;
    private TextMeshProUGUI gold;

    private void Awake()
    {
        image = GetComponent<Image>();
        gold = GetComponentInChildren<TextMeshProUGUI>();
        image.sprite = tower.towers[index].icon;
        gold.text = "$"+tower.towers[index].purchaseCost;
    }
    
    
}
