using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        [SerializeField] private int velocidad;

        [SerializeField] private Vector2 direccion;

        private Rigidbody2D rgbody;

        
        
        //variables dash 
        [SerializeField] private float veloDash;
        [SerializeField] private float enfriDash;
        [SerializeField] private float tiempoDash;
        [SerializeField] private float gravedadIni;
        [SerializeField] private bool puedeDash;



        [SerializeField] private bool puedeMover;

        //Animaciones Caminar
        private Animator playerAnimator;

        

        private void Start()
        {
            rgbody = GetComponent<Rigidbody2D>();

            gravedadIni = rgbody.gravityScale;

             veloDash = 3;
             tiempoDash = 0.3f;

             playerAnimator = GetComponent<Animator>();
        }


        private void Update()
        {   

            //Caminar
            direccion = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized; 

            //Animacion de Caminar. Gira el sprite
            playerAnimator.SetFloat("horizontal",direccion.x);
            playerAnimator.SetFloat("vertical",direccion.y);
            playerAnimator.SetFloat("Speed",direccion.sqrMagnitude);

            //Correr
            if (Input.GetKey(KeyCode.LeftShift) && puedeMover)
            {
                velocidad = 5;
            }else
            {
                velocidad = 2;
            }
            
            //Efriamiento Dash
            if (!puedeDash)
            {
                enfriDash = enfriDash + Time.deltaTime;
                if (enfriDash >= 0.6f)
                {
                    puedeDash = true;
                    enfriDash = 0f;
                }
            }
            // Llamada funcion para dashear
            if (Input.GetKey(KeyCode.C) && puedeDash == true)
            {
                StartCoroutine(Dash());
            }

            


        }

        //Funcion Dash
        private IEnumerator Dash()
        {
            puedeMover = false;
            puedeDash = false;
            rgbody.gravityScale = 0;
            rgbody.velocity = new Vector2(veloDash, 0);

            yield return new WaitForSeconds(tiempoDash);

            puedeMover = true;
            
            rgbody.gravityScale = gravedadIni;
        }
        private void FixedUpdate() 
        {
            //Caminar. 
            if (puedeMover)
            {
                rgbody.MovePosition(rgbody.position + direccion * velocidad * Time.fixedDeltaTime);
            }

            

        }


    }
}
