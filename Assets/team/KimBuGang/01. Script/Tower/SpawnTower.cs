using System;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public TowerStats towerStats;
    public GameObject mouse;
    
    private GameObject currentTower = null;
    private TowerStats.TowerStat currentTowerStat = null;

    public static SpawnTower Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
    }

    public void Spawn(int n)
    {
        if(currentTower == null)
        {
            currentTower = Instantiate(towerStats.towers[n].tower, mouse.transform);
            currentTowerStat = towerStats.towers[n];
            currentTower.GetComponent<TowerAttack>().enabled = false; currentTower.GetComponent<MouseFollow>().enabled = true;
            currentTower.transform.GetChild(0).transform.localScale = new Vector2(currentTowerStat.range * 2, currentTowerStat.range * 2);
        }
    }

    public void Cancel()
    {
        if (currentTower != null || currentTowerStat != null)
        {
            currentTower = null;
            currentTowerStat = null;
            Destroy(mouse.transform.GetChild(0).gameObject);
        }
    }

    public void Confirm()
    {
        if (currentTower != null && currentTowerStat != null)
        {
            TargetManager.Instance.AddTower(currentTowerStat);
            currentTower = null;
            currentTowerStat = null;
            Destroy(mouse.transform.GetChild(0).gameObject);
        }
        else if (currentTowerStat == null && currentTower == null)
            OnMouse.Instance.ClickTower();
    }
}