using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]
    public TowerStats _towerStats;
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
       TowerName(_towerStats); // Ÿ�� �̸�
       //TowerAbilityUpdate(_towerStats); // Ÿ�� �ɷ�ġ
       CostStart(_towerStats); // Ÿ�� Cost ����
    }

    public void TowerName(TowerStats _tower)
    {
        _name.text = _tower.name; // Ÿ�� �̸� So
    }

    public void TowerDamage(TowerAttack _tower)
    {
        //_textDamage.text = _tower.;
    }

    public void TowerUpdateGCD(TowerAttack _tower)
    {
        //_tower.
    }
    
    public void TowerAbilityUpdate(TowerAttack _tower)
    {
       
    }

    public void CostStart(TowerStats _tower)
    {
       // _textUpdateCost.text = _tower.upgradeCost.ToString(); // ������Ʈ Cost
        //_textSellCost.text = _tower.sellCost.ToString();     // �Ǹ� Cost
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
                _firstLevel++;
                _lastLevel++;
                _textFirstLevel.text = _firstLevel.ToString(); // ������ �����ϰ� ǥ��
                _textLastLevel.text = _lastLevel.ToString();   // ������ �����ϰ� ǥ��
                // TowerAbilityUpdate(_towerEn);
        }
    }
    
    public void Remove()
    {
        _tower.gameObject.SetActive(false); // �Ǹ�
        _ui.SetActive(false); // Uiâ�� ����
        //CostStart(_towerStartSo); //
    }

    
}
