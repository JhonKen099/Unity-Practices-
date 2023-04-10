using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{       
        //variable animator para abrir y cerrar cofre
        private Animator abrirCofre;
        

        //variable para acceder al objeto de chest_floor (trigger)
        [SerializeField] private chest_floor floor;

        
        
        void Start() {
                floor = FindObjectOfType<chest_floor>(); 
                abrirCofre = GetComponent<Animator>();

                
        }
        public void Update() {
                if (floor.puedeAbrir == 1 && Input.GetKeyDown(KeyCode.E))
                {
                        abrirCofre.SetFloat("OpenChest",floor.puedeAbrir);
                        floor.abierto = 1;
                }else if (floor.puedeAbrir == 0 )
                {
                        abrirCofre.SetFloat("OpenChest",floor.puedeAbrir);
                }
                



        }

}
