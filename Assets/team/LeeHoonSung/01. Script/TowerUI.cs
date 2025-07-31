using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]       
    //public TowerStatSO _towerStartSo;
    //public Tower _towerEnum;

    [Header("Ability")]  // 능력치
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textGcd;

    [Header("RemoveTower")] // 삭제 될 오브젝트
    GameObject _tower;

    [Header("UpdateAbility")]
    public int _DamageUpdate = 0;
    public float _RanageUpdate = 0;
  
    [Header("Maximum Level")]
    public int _maxiumLevel = 10;

    [Header("Cost")]
    public TextMeshProUGUI _textUpdateCost;
    public TextMeshProUGUI _textSellCost;

    private void Awake()
    {
        // _tower = 
    }

    private void Start()
    {
       //TowerName(_towerStartSo);
       //TowerAbility(_towerStartSo);
       //CostStart(_towerStartSo);
    }

    public void TowerName(TowerStatSO _tower)
    {
        _name.text = _tower.name;
    }

    public void TowerAbility(TowerStatSO _tower)
    {   
        _textDamage.text = _tower.dmg.ToString();
        _textGcd.text = _tower.attackSpeed.ToString();
    }

    public void TowerAbilityUpdate(Tower _tower)
    {
        _tower.dmg = _DamageUpdate;
        //_tower.attackspeed = _RanageUpdate;
    }

    public void CostStart(TowerStatSO _tower)
    {
        _textUpdateCost.text = _tower.UpdateCost.ToString();
        _textSellCost.text = _tower.SellCost.ToString();    
    }


    int _firstLevel = 1;
    int _lastLevel = 2;

    [Header("LevelText")] 
    public TextMeshProUGUI _textFirstLevel;
    public TextMeshProUGUI _textLastLevel;

    public void OnUpdateTower()
    {
        if(_firstLevel < _maxiumLevel )
        {
            _firstLevel++;
            _lastLevel++;
            _textFirstLevel.text = _firstLevel.ToString();
            _textLastLevel.text = _lastLevel.ToString();
        }
    }
    
    public void Remove()
    {
        _tower.gameObject.SetActive(false);
    }
}
