using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_floor : MonoBehaviour
{

    public float puedeAbrir; 
    public float abierto;
    


    void OnTriggerEnter2D(Collider2D other) {
         
        if (other.CompareTag("Player"))
        {   
            if (abierto == 1 )
            {
                return;
            }
            puedeAbrir = 1;
        }
    }

        void OnTriggerExit2D(Collider2D other) {
        
        
        if (other.CompareTag("Player"))
        {  
            if (abierto == 1 )
            {
                return;
            }
           puedeAbrir = 0;
           
        }
    }


}
