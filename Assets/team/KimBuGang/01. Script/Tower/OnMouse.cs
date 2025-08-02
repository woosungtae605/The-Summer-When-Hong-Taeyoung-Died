using System;
using DG.Tweening;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public GameObject UI;
    [Header("Cam Setting")]
    public Camera cam;
    public float CamSpeed;
    private bool clicked => UI.activeSelf;
    public bool onRoad { get; private set; } = false;
    public bool onTower { get; private set; } = false;

    public static OnMouse Instance;

    private TowerAttack tower;
    
    private void Awake()
    {
        if (Instance == null) 
            Instance = this; 
        else Destroy(gameObject);            
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !onRoad)
            SpawnTower.Instance.Confirm();
        else if (Input.GetMouseButtonDown(1)) 
            SpawnTower.Instance.Cancel();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tower" && !clicked)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            onTower = true;
            Debug.Log(onTower);
            tower = other.GetComponent<TowerAttack>();
        }
        else if (other.tag == "PreView" && !clicked)
            other.transform.GetChild(0).gameObject.SetActive(true);
        if (other.tag == "Road")
            onRoad = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tower"&& !clicked)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            onTower = false;
            tower = null;
        }
        else if (other.tag == "PreView" && !clicked)
            other.transform.GetChild(0).gameObject.SetActive(false);
        if (other.tag == "Road")
            onRoad = false;
    }

    public void ClickTower()
    {
        if (onTower && UI.GetComponentInChildren<TowerUI>()._towerAttack == null)
        {
            UI.GetComponentInChildren<TowerUI>()._towerAttack = tower;
            UI.SetActive(true);
        }
    }

    public void TowerDestroy()
    {
        tower = null;
        onTower = false;
    }

    private void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (pos.x < 0f)
        {
            pos.x = 0f;
            cam.transform.DOMoveX(cam.transform.position.x - CamSpeed, 1);
        }
        if (pos.x > 1f)
        {
            pos.x = 1f;
            cam.transform.DOMoveX(cam.transform.position.x + CamSpeed, 1);
        }
        if (pos.y < 0f)
        {
            pos.y = 0f;
            cam.transform.DOMoveY(cam.transform.position.y - CamSpeed, 1);
        }
        if (pos.y > 1f)
        {
            pos.y = 1f;
            cam.transform.DOMoveY(cam.transform.position.y + CamSpeed, 1);
        }
        
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
