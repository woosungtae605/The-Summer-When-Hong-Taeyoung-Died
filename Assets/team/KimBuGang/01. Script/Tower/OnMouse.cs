using System;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public GameObject UI;
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
            tower = other.GetComponent<TowerAttack>();
            Debug.Log("OnMouse");
        }
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
            Debug.Log("LeftMouse");
        }
        if (other.tag == "Road")
            onRoad = false;
    }

    public void ClickTower()
    {
        Debug.Log("BeforeClick");
        if (onTower)
        {
            Debug.Log("UI");
            UI.GetComponentInChildren<TowerUI>()._towerAttack = tower;
            UI.SetActive(true);
        }
    }
}
