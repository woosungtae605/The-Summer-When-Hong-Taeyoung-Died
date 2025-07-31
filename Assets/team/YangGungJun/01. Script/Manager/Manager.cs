using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager manager;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(manager);
        }
        else
            Destroy(gameObject);

        Initialize();
    }
    public TowerManager tower { get; private set; }
    public void Initialize()
    {
        tower = GetComponentInChildren<TowerManager>();
        Spwan = GetComponentInChildren<SpawnManager>();
    }
    public SpawnManager Spwan { get; private set; }
}
