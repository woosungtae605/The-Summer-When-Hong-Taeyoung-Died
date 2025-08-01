using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TowerStats",  fileName = "TowerStats")]
public class TowerStats : ScriptableObject
{
    [System.Serializable]
    public class TowerStat
    {
        public Sprite icon;
        public string name;
        public GameObject tower;
        public int dmg;
        public float rate;
        public float range;
        public int purchaseCost;
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
    
    public List<TowerStat> towers = new List<TowerStat>();
}
