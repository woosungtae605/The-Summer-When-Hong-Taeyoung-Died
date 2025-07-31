using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{    
    public TowerStatSO _towerStartSo;
    [Header("Ability")]
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textGcd;

    [Header("RemoveTower")]
    GameObject _tower;

    [Header("AbilityUpdate")]
    public int DamageUpdate = 0;
    public int RanageUpdate = 0;  
    
    [Header("Maximum Level")]
    public int _maxiumLevel = 10;

    private void Awake()
    {
        // _tower = 
    }

    private void Start()
    {
       TowerName(_towerStartSo);
       TowerAbility(_towerStartSo);
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

    public void TowerAbilityUpdate(TowerStatSO _tower)
    {

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
