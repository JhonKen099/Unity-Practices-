using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class playervida : MonoBehaviour
{

    public playerarma arma;
    

    //barra de vida
    public float barravida = 6f;

    //playerarma coneccion
    public int daño_vulnerable;

    public float recarga;

    //damage
    public int hitsPoints = 1;
    //invulnerable
    public float invulnerable = 0;
    public bool invulne = false;


    void Start()
    {

    }

        // Update is called once per frame
        void Update()
    {

        playerarma playerarma = GetComponent<playerarma>();

        daño_vulnerable = playerarma.daño_vulnerable;

        recarga = playerarma.recarga;




        //barra de vida
        barravida = Mathf.Clamp(barravida, 0, 6);

        if (invulne == true && invulnerable <= 2)
        {
            //agregar invulnerable
            invulnerable += Time.deltaTime;

            if (daño_vulnerable == 1)
            {
                recarga += Time.deltaTime;

            }

            return;
        }
        if (invulnerable > 2)
        {
            invulne = false;
            invulnerable = 0;
        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" && invulne == false)
        {
            Debug.Log("muere planta muere!!" + hitsPoints + "de daño");
            barravida -= hitsPoints + daño_vulnerable;


            //bolean invulnerable
            invulne = true;
        }
    }

    public float GetVida()
    {
        return barravida;
    }

   



}
