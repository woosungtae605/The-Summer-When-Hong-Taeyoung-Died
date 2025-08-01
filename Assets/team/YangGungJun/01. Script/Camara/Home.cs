using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] int Hp = 10;
    [SerializeField] StageClearUI clearUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            GetDmg(1);
        }
    }
    private void GetDmg(int dmg)
    {
        Hp -= dmg;
        CamaraControll.camaraControl.DownCamara(1);

        if (Hp <= 0)
            clearUI.PrintText(false);
    }
}
