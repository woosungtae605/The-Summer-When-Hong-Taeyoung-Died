using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]
    public TowerAttack _towerAttack;
    public CostManager _costManager;

    [Header("Ability")]  // 능력치
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textRange;
    public TextMeshProUGUI _textGcd;

    [Header("UpgradeText")]
    public TextMeshProUGUI _upgradeDamage;
    public TextMeshProUGUI _upgradeRange;
    public TextMeshProUGUI _upgradeGcd;

    [Header("UpdateAbility")]
    public int _DamageUpdate = 0; // 데미지 증가 업데이트
    public float _RanageUpdate = 0; // 사거리 증가 업데이트
    public float _GcdUpdate = 0;    // 쿨타임 증가 업데이트
    public int _UpdateCostUpdate = 0;   // 업그레이드 업데이트
    public int _SellCostUpdate = 0;     // 판매 업데이트

    [Header("Maximum Level")]
    public int _maxiumLevel = 10; // 최대 레벨 개수

    [Header("Cost")]
    public TextMeshProUGUI _textUpdateCost; // 업그레이드 Cost
    public TextMeshProUGUI _textSellCost;   // 판매 Cost

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
        TowerName(_towerAttack); // 타워 이름
        StartTower();
        UpgradeStart(_towerAttack);
        TowerAbilityMiray(_towerAttack);
    }

    public void TowerName(TowerAttack _tower)
    {
        _name.text = _tower.name; // 타워 이름 So
    }

    public void TowerDamage(TowerAttack _tower)
    {
        _textDamage.text = _tower.damage.ToString();
    }

    public void TowerAbilityMiray(TowerAttack _tower)
    {
        _mirayDamage = _tower.damage;
        _mirayRange = _tower.range;
        _mirayGcd = _tower.rate;
        _mirayDamage += _DamageUpdate;
        _mirayRange += _RanageUpdate;
        _mirayGcd += _GcdUpdate;

        _mirayDamamge.text = _mirayDamage.ToString();
        _mirayRange2.text = _mirayRange.ToString();
        _mirayGCd.text = _mirayGcd.ToString();
    }

    public void TowerUpdateGCD(TowerAttack _tower)
    {
        _textGcd.text = _tower.rate.ToString();
    }

    public void TowerRange(TowerAttack _tower)
    {
        _textRange.text = _tower.range.ToString();
    }
    
    public void TowerAbilityUpdate(TowerAttack _tower)
    {
        _tower.damage += _DamageUpdate;
        _tower.rate += _GcdUpdate;
        _tower.range += _RanageUpdate;
        _tower.upgradeCost += _UpdateCostUpdate;
        _tower.sellCost += _SellCostUpdate;
    }

    public void TowerAbilityMax(TowerAttack _tower)
    {
       // _tower.upgradeCost = 
    }

    public void UpgradeStart(TowerAttack _tower)
    {
        _upgradeDamage.text = _tower.damage.ToString();
        _upgradeRange.text = _tower.range.ToString();
        _upgradeGcd.text = _tower.rate.ToString();
    }

    public void CostStart(TowerAttack _tower)
    {
        _textUpdateCost.text = _tower.upgradeCost.ToString(); // 업데이트 Cost
        _textSellCost.text = _tower.sellCost.ToString();     // 판매 Cost
    }

    public void StartTower()
    {
        TowerDamage(_towerAttack);
        TowerUpdateGCD(_towerAttack);
        TowerRange(_towerAttack);
        CostStart(_towerAttack);
    }

    int _firstLevel = 1; // 원래 레벨
    int _lastLevel = 2;  // 증가 레벨

    [Header("LevelText")] 
    public TextMeshProUGUI _textFirstLevel;
    public TextMeshProUGUI _textLastLevel;

    public void OnUpdateTower()
    {
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

               _textFirstLevel.text = _firstLevel.ToString(); // 레벨이 증가하고 표현
                 // 레벨이 증가하고 표현
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
    
    


    public void Remove()
    {
        
    }    
}
