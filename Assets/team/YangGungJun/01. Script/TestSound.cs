using UnityEngine;

public class TestSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }
}
