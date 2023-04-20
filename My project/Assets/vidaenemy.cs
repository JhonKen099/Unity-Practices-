using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaenemy : MonoBehaviour
{
    [SerializeField] private float vida;
   
    
    void Start() {
        vida = 500;
        
    }


    public void tomarDaño(float dañoRecibido)
    {
        vida -= dañoRecibido;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }  
    }


}
