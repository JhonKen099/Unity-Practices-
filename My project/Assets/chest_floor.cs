using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_floor : MonoBehaviour
{


    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        { 
            
            
                Debug.Log("bien");
           
            
            
            
        }
        

        
    }


}
