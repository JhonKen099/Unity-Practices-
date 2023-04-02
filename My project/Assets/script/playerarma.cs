using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerarma : MonoBehaviour
{

    //barra caliente

    public float barra_arma = 4f;

    public float recarga = 0;

    public bool tempo = false;

    //daño +1 al estar vulnerable
    public int daño_vulnerable = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //barra caliente


        //disparar - activar recarga de una bala cada que se pulsa la x - activar recarga completa, y tiempo de vulnerabilidad +1
        if (Input.GetKeyDown(KeyCode.X) && barra_arma > 0)
        {
            //    if(barra_arma == 0)
            //    {
            //return;
            //    }


            barra_arma = Mathf.Clamp(barra_arma, 1, 4);
            barra_arma -= 1;

            recarga = 0;

        }
        //
        if (barra_arma == 0 && recarga >= 0 && recarga < 5)
        {

            recarga += Time.deltaTime;

            daño_vulnerable = 1;


            return;

        }
        if (barra_arma < 4 && recarga >= 0 && recarga < 2)
        {
            recarga += Time.deltaTime;
        }

        if (barra_arma == 0 && recarga >= 5
            )
        {

            barra_arma = 4f;
            recarga = 0;
            daño_vulnerable = 0;
        }

        if (barra_arma <= 4 && barra_arma > 0 && recarga >= 2)
        {
            barra_arma += 1f;
            recarga = 0;
        }
    }

    public float Get_daño_vulnerable()
    {
        return daño_vulnerable;
    }

    public float Get_recarga()
    {
        return recarga;
    }
}
