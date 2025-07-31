using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]       
    public TowerStatSO _towerStartSo;
    public Tower _towerEn;
    public CostManager _costManager;

    [Header("Ability")]  // �ɷ�ġ
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textRange;
    public TextMeshProUGUI _textGcd;

    [Header("RemoveTower")] // ���� �� ������Ʈ
    public GameObject _tower;
    public GameObject _ui;

    [Header("UpdateAbility")]
    public int _DamageUpdate = 0; // ������ ���� ������Ʈ
    public float _RanageUpdate = 0; // ��Ÿ� ���� ������Ʈ
    public float _GcdUpdate = 0;    // ��Ÿ�� ���� ������Ʈ
    public int _UpdateCostUpdate = 0;   // ���׷��̵� ������Ʈ
    public int _SellCostUpdate = 0;     // �Ǹ� ������Ʈ

    [Header("Maximum Level")]
    public int _maxiumLevel = 10; // �ִ� ���� ����

    [Header("Cost")]
    public TextMeshProUGUI _textUpdateCost; // ���׷��̵� Cost
    public TextMeshProUGUI _textSellCost;   // �Ǹ� Cost

    private void Start()
    {
       TowerName(_towerStartSo); // Ÿ�� �̸�
        TowerAbilityUpdate(_towerEn); // Ÿ�� �ɷ�ġ
       CostStart(_towerStartSo); // Ÿ�� Cost ����
    }

    public void TowerName(TowerStatSO _tower)
    {
        _name.text = _tower.name; // Ÿ�� �̸� So
    }

    public void TowerUpdateGCD(Tower _tower)
    {
        _tower.AttackSpeed(_GcdUpdate);
    }
    
    public void TowerAbilityUpdate(Tower _tower)
    {
       
    }

    public void CostStart(TowerStatSO _tower)
    {
        _textUpdateCost.text = _tower.UpdateCost.ToString(); // ������Ʈ Cost
        _textSellCost.text = _tower.SellCost.ToString();     // �Ǹ� Cost
    }

    int _firstLevel = 1; // ���� ����
    int _lastLevel = 2;  // ���� ����

    [Header("LevelText")] 
    public TextMeshProUGUI _textFirstLevel;
    public TextMeshProUGUI _textLastLevel;

    public void OnUpdateTower()
    {
        if(_firstLevel < _maxiumLevel)
        {
            Debug.Log("pushButton");
                _firstLevel++;
                _lastLevel++;
                _textFirstLevel.text = _firstLevel.ToString(); // ������ �����ϰ� ǥ��
                _textLastLevel.text = _lastLevel.ToString();   // ������ �����ϰ� ǥ��
                // TowerAbilityUpdate(_towerEn);
        }
    }
    
    public void Remove()
    {
        Debug.Log("RemoveButton");
        _tower.gameObject.SetActive(false); // �Ǹ�
        _ui.SetActive(false); // Uiâ�� ����
        CostStart(_towerStartSo); //
    }

    
}
