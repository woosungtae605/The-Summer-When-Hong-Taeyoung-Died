using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<TowerAttack> towers;
    public GameObject testTarget;

    public void AddTower(TowerStats.TowerStat towerStat)
    {
        GameObject tower = Instantiate(towerStat.tower,
            new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0),
            Quaternion.identity);
        TowerAttack towerScript = tower.GetComponent<TowerAttack>();
        towers.Add(towerScript);
        towerScript.target = testTarget;
        towerScript.damage = towerStat.dmg;
        towerScript.rate = towerStat.rate;
        towerScript.range = towerStat.range;
        towerScript.bulletSpeed = towerStat.bulletSpeed;
        tower.transform.GetChild(0).transform.localScale = new Vector2(towerStat.range * 2, towerStat.range * 2);
    }
}