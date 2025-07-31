using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<TowerAttack> towers;
    public GameObject testTarget;

    public void AddTower(GameObject tower)
    {
        TowerAttack towerScript = tower.GetComponent<TowerAttack>();
        towers.Add(towerScript);
        towerScript.target = testTarget;
    }
}