using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

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
    }
    public void ShakeCamara()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine());
    }
    public void DownCamara(Camera camera, float dmg)
    {
        camera.orthographicSize -= dmg;
    }
    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
