using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    [SerializeField] int BgmId;
    [SerializeField] AudioSource audioSource;
    private void Start()
    {
        SetBGM(BgmId);
    }
    public void SetBGM(int BgmId)
    {
        audioSource.clip = Manager.manager.Sound.SetSoundBGM(BgmId);
        audioSource.Play();
    }
}
