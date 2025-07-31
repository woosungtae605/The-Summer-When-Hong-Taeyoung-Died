using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TowerStats",  fileName = "TowerStats")]
public class TowerStats : ScriptableObject
{
    [System.Serializable]
    public class TowerStat
    {
        public string name;
        public GameObject tower;
        public int dmg;
        public float rate;
        public float range;
    }
    
    public List<TowerStat> towers = new List<TowerStat>();
}
