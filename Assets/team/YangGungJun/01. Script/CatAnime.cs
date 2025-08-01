using UnityEngine;

public class CatAnime : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    private void Start()
    {
        InvokeRepeating("SetAnime", 0, 5);
    }
    private void SetAnime()
    {
        int randomValue = Random.Range(1, 3);
        if (randomValue == 1)
        {
            audioSource.clip = Manager.manager.Sound.SetSoundSFX(3);
            audioSource.Play();
            animator.SetBool("isSleep", true);
          
        }
        else if (randomValue == 2)
        {
            animator.SetBool("isSleep", false);
            audioSource.clip = Manager.manager.Sound.SetSoundSFX(2);
            audioSource.Play();
        }
        else
        {
           
        }
    }
    private void Meow()
    {

    }

}
