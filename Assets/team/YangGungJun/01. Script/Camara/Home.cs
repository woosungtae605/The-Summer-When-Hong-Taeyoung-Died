using System;
using UnityEngine;

public class Home : MonoBehaviour
{  
    [SerializeField] int Hp = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Destroy(collision.gameObject);
            GetDmg();
        }
    }
    private void GetDmg()
    {
        Hp -= 1;
        if (Hp <= 0)
        {
            CamaraControll.camaraControl.ShakeCamara();

        }
    }
}
