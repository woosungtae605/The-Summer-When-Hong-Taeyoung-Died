using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public TowerStats towerStats;
    [SerializeField] TargetManager targetManager;
    
    private TowerStats.TowerStat currentTower = null;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            currentTower = towerStats.towers[0];
        if (Input.GetKeyUp(KeyCode.Alpha2))
            currentTower = towerStats.towers[1];
        if (Input.GetKeyUp(KeyCode.Alpha3))
            currentTower = towerStats.towers[2];
        
        if (Input.GetMouseButtonUp(0))
            if (currentTower != null)
            {
                targetManager.AddTower(Instantiate(currentTower.tower,
                    new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0),
                    Quaternion.identity));
                currentTower = null;
            }
    }
}
