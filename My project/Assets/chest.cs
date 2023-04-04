using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D other)            
        {
            if (other.collider.CompareTag("Player") && Input.GetKey(KeyCode.E))
            {
                Debug.Log("Abres Cofre");
            }

        }
}
