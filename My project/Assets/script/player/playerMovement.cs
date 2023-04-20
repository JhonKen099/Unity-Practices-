using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class playerMovement : MonoBehaviour
    {
        [SerializeField] private int velocidad;

        [SerializeField] private Vector2 direccion;

        [SerializeField] private Rigidbody2D rgbody;

        
        
        //variables dash 
        [SerializeField] private float veloDash;
        [SerializeField] private float enfriDash;
        [SerializeField] private float tiempoDash;
        [SerializeField] private float gravedadIni;
        [SerializeField] private bool puedeDash;
        [SerializeField] private float posix;
        [SerializeField] private float posiy;

        [SerializeField] private bool puedeMover;

        //Animaciones Caminar
        [SerializeField] private Animator playerAnimator;

        private void Start()
        {
            rgbody = GetComponent<Rigidbody2D>();

            gravedadIni = rgbody.gravityScale;

             veloDash = 5;
             tiempoDash = 0.3f;

             playerAnimator = GetComponent<Animator>();

             puedeMover = true;

             posix = 1;
        }


        private void Update()
        {   

            //Caminar
            direccion = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized; 

            //Animacion de Caminar
            playerAnimator.SetFloat("horizontal",direccion.x);
            playerAnimator.SetFloat("vertical",direccion.y);
            playerAnimator.SetFloat("Speed",direccion.sqrMagnitude);

            //Animacion De "Uy Quieto"
            if (Input.GetAxisRaw("Horizontal") != 0  
            || Input.GetAxisRaw("Vertical") != 0  || 
            Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                playerAnimator.SetFloat("lastHorizontal",direccion.x);
                playerAnimator.SetFloat("LastVertical",direccion.y);

                // direccionamiento del dash
                posix = Input.GetAxisRaw("Horizontal");
                posiy = Input.GetAxisRaw("Vertical");
            }

            //Correr
            if (Input.GetKey(KeyCode.LeftShift) && puedeMover)
            {
                velocidad = 5;
            }else
            {
                velocidad = 3;
            }
            
            //Enfriamiento Dash
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
                        StartCoroutine(Dash(posix, posiy));
                }

        }

        //Funcion Dash
        private IEnumerator Dash(float velox, float veloy)
        {
            puedeMover = false;
            puedeDash = false;
            rgbody.gravityScale = 0;

            rgbody.velocity = new Vector2(velox * veloDash, veloy * veloDash);

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
