using UnityEngine;
using UnityEngine.Rendering;

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

    public SpawnManager Spwan { get; private set; }
    public SoundManager Sound { get; private set; }
    public BGMmanager BGM { get; private set; }
    public VolumeManager Volume { get; private set; }
    public void Initialize()
    {
        Spwan = GetComponentInChildren<SpawnManager>();
        Sound = GetComponentInChildren<SoundManager>();
        BGM = GetComponentInChildren<BGMmanager>();
        Volume = GetComponentInChildren<VolumeManager>();
    }

}
