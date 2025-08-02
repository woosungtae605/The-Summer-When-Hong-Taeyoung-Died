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
        StartTower();
    }

    private void OnEnable()
    {
       
        _TowerPrefab = _towerAttack.gameObject;
        TowerName(_towerAttack); 
        UpgradeStart(_towerAttack);
        TowerAbilityMiray(_towerAttack);
        OnIcon(_towerAttack);
        InitLevel();
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
        _mirayDamage += _tower.stat.damageUpgrade;
        _mirayRange += _tower.stat.rangeUpgrade;
        _mirayGcd += _tower.stat.rateUpgrade;

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
        Debug.Log(_tower.stat.dmg);
        _tower.stat.dmg += _tower.stat.damageUpgrade;
        _tower.stat.rate /= _tower.stat.rateUpgrade;
        _tower.stat.range += _tower.stat.rangeUpgrade;
        _tower.gameObject.transform.GetChild(0).transform.localScale = new Vector3(_tower.stat.range*2, _tower.stat.range*2, 1);
        _tower.stat.upgradeCost += _tower.stat.updateCostUpgrade;
        _tower.stat.sellCost += _tower.stat.sellCostUpgrade;        
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

    [Header("LevelText")] 
    public TextMeshProUGUI _textFirstLevel;
    public TextMeshProUGUI _textLastLevel;

    public void OnUpdateTower()
    {
        if ((int)_channel.Gold >= _towerAttack.stat.upgradeCost)
        {
            TowerAbilityUpdate(_towerAttack);
            UpgradeStart(_towerAttack);
            StartTower();
            TowerAbilityMiray(_towerAttack);
            Debug.Log(1);
            _channel.ChangeGold(_towerAttack.stat.upgradeCost, GoldTypeEnum.SPEND);
            _towerAttack.stat.lvl++;
            if (_towerAttack.stat.lvl < _towerAttack.stat._maxiumLevel)
            {
                if (_towerAttack.stat.lvl + 1 < _towerAttack.stat._maxiumLevel)
                {
                    _textLastLevel.text = (_towerAttack.stat.lvl + 1).ToString();
                }
                else
                    _textLastLevel.text = "Max";

                _textFirstLevel.text = _towerAttack.stat.lvl.ToString();
            }
            else if (_towerAttack.stat.lvl >= _towerAttack.stat._maxiumLevel)
            {
                _maxText.gameObject.SetActive(true);
                _levelText.gameObject.SetActive(false);
                _textUpdateCost.text = "Max";
                _UiDelete.SetActive(false);
                _maxLevel.gameObject.SetActive(true);

            }
            else if(_towerAttack.stat.lvl == _towerAttack.stat._maxiumLevel)
            {
                InitLevel();
            }
        }
    }

    private void InitLevel()
    {     
        Debug.Log(2);
        if (_towerAttack.stat.lvl < _towerAttack.stat._maxiumLevel)
        {
            
            _maxText.gameObject.SetActive(false);
            _levelText.gameObject.SetActive(true);
            _UiDelete.SetActive(true);
            _maxLevel.gameObject.SetActive(false); 
            if (_towerAttack.stat.lvl + 1 < _towerAttack.stat._maxiumLevel)
            {
                _textLastLevel.text = (_towerAttack.stat.lvl + 1).ToString();
            }
            else
                _textLastLevel.text = "Max";

            _textFirstLevel.text = _towerAttack.stat.lvl.ToString();
        }
        else if (_towerAttack.stat.lvl == _towerAttack.stat._maxiumLevel)
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
        _channel.ChangeGold(_towerAttack.stat.sellCost, GoldTypeEnum.GET);
        TargetManager.Instance.towers.Remove(_towerAttack);
        Destroy(_TowerPrefab);
        _towerAttack = null;
        _TowerUI.SetActive(false);
    }    
}
