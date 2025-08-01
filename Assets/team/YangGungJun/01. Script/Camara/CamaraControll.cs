using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class CamaraControll : MonoBehaviour
{
    public static CamaraControll camaraControl;
    public float shakeDuration = 0.6f;
    public float shakeMagnitude = 0.1f;
    private Vector3 originalPosition;
    [SerializeField] Camera camera1;
    private void Awake()
    {
        if (camaraControl == null)
        {
            camaraControl = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        originalPosition = camera1.transform.localPosition;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void DownCamara(float dmg)
    {
        camera1.orthographicSize -= dmg;
        StartCoroutine(ShakeCoroutine());
    }
    public void SetCamaraSize(int size)
    {
        Debug.Log("asdsadasd");
        camera1.orthographicSize = size;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopAllCoroutines();
    }

    public IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;
       
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            camera1.transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }
        camera1.transform.localPosition = originalPosition;
    }

}
