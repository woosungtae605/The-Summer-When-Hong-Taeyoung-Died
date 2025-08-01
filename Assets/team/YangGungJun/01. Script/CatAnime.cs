using UnityEngine;

public class CatAnime : MonoBehaviour
{
    
     [SerializeField] Animator animator;
    private void Start()
    {
        InvokeRepeating("SetAnime",0,5);
    }
    private void SetAnime()
    {
        int randomValue = Random.Range(1, 3);
        if (randomValue == 1)
        {
            animator.SetBool("isSleep", true);
        }
        else
        {
            animator.SetBool("isSleep", false);
        }
    }
   
}
