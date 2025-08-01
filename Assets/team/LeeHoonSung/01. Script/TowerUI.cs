using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]
    public TowerAttack _towerAttack;
    public Image _icon;
    public GoldChannelSO _channel;
    [Header("Prefab")]
    public GameObject _TowerPrefab;
    public GameObject _TowerUI;

    [Header("Ability")]  // �ɷ�ġ
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textRange;
    public TextMeshProUGUI _textGcd;

    [Header("UpgradeText")]
    public TextMeshProUGUI _upgradeDamage;
    public TextMeshProUGUI _upgradeRange;
    public TextMeshProUGUI _upgradeGcd;

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

    int _mirayDamage;
    float _mirayRange;
    float _mirayGcd;

    [Header("MirayAbility")]
    public TextMeshProUGUI _mirayDamamge;
    public TextMeshProUGUI _mirayRange2;
    public TextMeshProUGUI _mirayGCd;

    [Header("Max")]
    public TextMeshProUGUI _maxText;
    public GameObject _levelText;
    public GameObject _UiDelete;
    public GameObject _maxLevel;

    private void Awake()
    {
        _maxText.gameObject.SetActive(false);
        _maxLevel.gameObject.SetActive(false);
    }

    private void Start()
    {
        TowerName(_towerAttack); // Ÿ�� �̸�
        StartTower();
        UpgradeStart(_towerAttack);
        TowerAbilityMiray(_towerAttack);
        OnIcon(_towerAttack);
    }

    public void OnIcon(TowerAttack _tower)
    {
       _icon.sprite = _tower.stat.icon;
    }

    public void TowerName(TowerAttack _tower)
    {
        _name.text = _tower.stat.name; // Ÿ�� �̸� So
    }

    public void TowerDamage(TowerAttack _tower)
    {
        _textDamage.text = _tower.stat.dmg.ToString();
    }

    public void TowerAbilityMiray(TowerAttack _tower)
    {
        _mirayDamage = _tower.stat.dmg;
        _mirayRange = _tower.stat.range;
        _mirayGcd = _tower.stat.rate;
        _mirayDamage += _DamageUpdate;
        _mirayRange += _RanageUpdate;
        _mirayGcd += _GcdUpdate;

        _mirayDamamge.text = _mirayDamage.ToString();
        _mirayRange2.text = _mirayRange.ToString();
        _mirayGCd.text = _mirayGcd.ToString();
    }

    public void TowerUpdateGCD(TowerAttack _tower)
    {
        _textGcd.text = _tower.stat.rate.ToString();
    }

    public void TowerRange(TowerAttack _tower)
    {
        _textRange.text = _tower.stat.range.ToString();
    }
    
    public void TowerAbilityUpdate(TowerAttack _tower)
    {       
        _tower.stat.dmg += _DamageUpdate;
        _tower.stat.rate += _GcdUpdate;
        _tower.stat.range += _RanageUpdate;
        _tower.stat.upgradeCost += _UpdateCostUpdate;
        _tower.stat.sellCost += _SellCostUpdate;        
    }

    public void UpgradeStart(TowerAttack _tower)
    {
        _upgradeDamage.text = _tower.stat.dmg.ToString();
        _upgradeRange.text = _tower.stat.range.ToString();
        _upgradeGcd.text = _tower.stat.rate.ToString();
    }

    public void CostStart(TowerAttack _tower)
    {
        _textUpdateCost.text = _tower.stat.upgradeCost.ToString(); // ������Ʈ Cost
        _textSellCost.text = _tower.stat.sellCost.ToString();     // �Ǹ� Cost
    }

    public void StartTower()
    {
        TowerDamage(_towerAttack);
        TowerUpdateGCD(_towerAttack);
        TowerRange(_towerAttack);
        CostStart(_towerAttack);
    }

    int _firstLevel = 1; // ���� ����
    int _lastLevel = 2;  // ���� ����

    [Header("LevelText")] 
    public TextMeshProUGUI _textFirstLevel;
    public TextMeshProUGUI _textLastLevel;

    public void OnUpdateTower(TowerAttack _tower)
    {
        if((int)_channel.Gold >= _tower.stat.upgradeCost)
        {       
            _channel.ChangeGold((ulong)_tower.stat.upgradeCost,GoldTypeEnum.SPEND);
            if(_firstLevel < _maxiumLevel)
            {
                _firstLevel++;

            if (_lastLevel < _maxiumLevel)
            {
                _lastLevel++;
                _textLastLevel.text = _lastLevel.ToString();
            }
            else
                _textLastLevel.text = "Max";

               _textFirstLevel.text = _firstLevel.ToString(); // ������ �����ϰ� ǥ��
                 // ������ �����ϰ� ǥ��
                TowerAbilityUpdate(_towerAttack);
                StartTower();
                UpgradeStart(_towerAttack);
                TowerAbilityMiray(_towerAttack);
            }
        else if (_firstLevel == _maxiumLevel)
        {
            _maxText.gameObject.SetActive(true);
            _levelText.gameObject.SetActive(false);
            _textUpdateCost.text = "Max";
            _UiDelete.SetActive(false);
            _maxLevel.gameObject.SetActive(true);
            
        }
        }
    }
    
    public void Remove(TowerAttack _tower)
    {
        _channel.ChangeGold((ulong)_tower.stat.sellCost, GoldTypeEnum.GET);
        _TowerPrefab.SetActive(false);
        _TowerUI.SetActive(false);
    }    
}
