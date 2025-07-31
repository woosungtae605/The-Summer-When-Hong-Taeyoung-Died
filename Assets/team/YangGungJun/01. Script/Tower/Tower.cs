using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private TowerStatSO TowerStatSO;
    public int dmg { set; private get; }
    public float attackSpeed { set; private get; }
    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        dmg = TowerStatSO.dmg;
        attackSpeed = TowerStatSO.attackSpeed;
    }
    public abstract void Shoot();
}
