using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Animator open_closed;
    private door_closed bloqueo;

    [SerializeField] private float abrir;

    void Start() {
        open_closed = GetComponent<Animator>();
        bloqueo = FindObjectOfType<door_closed>();

    }

    void Update(){
        if (abrir == 1 && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GameObject.FindWithTag("bloque"));
            open_closed.SetFloat("Open",abrir);
            abrir = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && abrir != 2)
        {
            abrir = 1;

        }
    }

        void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player") && abrir != 2)
        {
            abrir = 0;

        }
    }

    

}
