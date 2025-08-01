using UnityEngine;

[CreateAssetMenu(fileName = "TowerOwnStatSO", menuName = "Scriptable Objects/TowerOwnStatSO")]
public class TowerOwnStatSO : ScriptableObject
{
    public Sprite icon;
    public string name;
    public GameObject tower;
    public int lvl = 1;
    public int dmg;
    public float rate;
    public float range;
    public float bulletSpeed;
    public int upgradeCost;
    public int sellCost;

    [Header("Upgrade")]
    public int damageUpgrade;
    public float rateUpgrade;
    public float rangeUpgrade;
    public int updateCostUpgrade;
    public int sellCostUpgrade;

    [Header("Maximum Level")]
    public int _maxiumLevel = 10;

    public GameObject bullet;
}
