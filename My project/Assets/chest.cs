using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D other)            
        {
            if (other.collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
              
                    Debug.Log("Estas Cerca del cofre");
               
                            
            }

        }

        private void OnCollisionStay2D(Collision2D other)            
        {
            if (other.collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
            
                    Debug.Log("Abres Cofre");
               
                            
            }

        }
        private void OnCollisionExit2D(Collision2D other)            
        {
            if (other.collider.CompareTag("Player"))
            {
               
                    Debug.Log("Te alejas del cofre");
              
                            
            }

        }
}
