using UnityEngine;

public class BGMmanager : MonoBehaviour
{
   
    [SerializeField] AudioSource audioSource;
    private void Start()
    {
        
    }
    public void SetBGM(int BgmId)
    {
        audioSource.clip = Manager.manager.Sound.SetSoundBGM(BgmId);
        audioSource.Play();
    }
}
