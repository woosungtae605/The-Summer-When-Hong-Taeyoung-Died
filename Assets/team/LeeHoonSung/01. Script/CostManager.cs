using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public TextMeshProUGUI _text;

    public int _cost = 0;
    public int MaxmumCost = 9999;

    TowerUI _towerUI;

    public TowerStatSO _tower;

    private void Awake()
    {
        _towerUI = GetComponent<TowerUI>();
    }

    private void Start()
    {
        _text.text = _cost.ToString();
    }

    private void CostUpdate()
    {
        if(_cost <= MaxmumCost)
        _text.text = _cost.ToString();
    }

    public void CostUpdateCheck()
    {
        _cost -= _tower.UpdateCost;
    }



    public void Test()
    {
        _cost += 300;
        CostUpdate();
    }
}
