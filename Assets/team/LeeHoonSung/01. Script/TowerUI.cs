using TMPro;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [Header("publicObject")]       
    public TowerStatSO _towerStartSo;
    public Tower _towerEn;
    public CostManager _costManager;

    [Header("Ability")]  // 능력치
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _textDamage;
    public TextMeshProUGUI _textRange;
    public TextMeshProUGUI _textGcd;

    [Header("RemoveTower")] // 삭제 될 오브젝트
    public GameObject _tower;
    public GameObject _ui;

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

    private void Start()
    {
       TowerName(_towerStartSo); // 타워 이름
        TowerAbilityUpdate(_towerEn); // 타워 능력치
       CostStart(_towerStartSo); // 타워 Cost 관련
    }

    public void TowerName(TowerStatSO _tower)
    {
        _name.text = _tower.name; // 타워 이름 So
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
        _textUpdateCost.text = _tower.UpdateCost.ToString(); // 업데이트 Cost
        _textSellCost.text = _tower.SellCost.ToString();     // 판매 Cost
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
            Debug.Log("pushButton");
                _firstLevel++;
                _lastLevel++;
                _textFirstLevel.text = _firstLevel.ToString(); // 레벨이 증가하고 표현
                _textLastLevel.text = _lastLevel.ToString();   // 레벨이 증가하고 표현
                // TowerAbilityUpdate(_towerEn);
        }
    }
    
    public void Remove()
    {
        Debug.Log("RemoveButton");
        _tower.gameObject.SetActive(false); // 판매
        _ui.SetActive(false); // Ui창도 삭제
        CostStart(_towerStartSo); //
    }

    
}
