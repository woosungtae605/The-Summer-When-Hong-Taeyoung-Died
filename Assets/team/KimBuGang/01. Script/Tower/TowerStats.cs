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
        public Color bulletColor;
    }
    
    public List<TowerStat> towers = new List<TowerStat>();
}
