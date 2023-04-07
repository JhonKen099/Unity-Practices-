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

        [SerializeField] private bool girarVista;
        
        //variables dash 
        [SerializeField] private float veloDash;
        [SerializeField] private float enfriDash;
        [SerializeField] private float tiempoDash;
        [SerializeField] private float gravedadIni;
        [SerializeField] private bool puedeDash;



        [SerializeField] private bool puedeMover;

        [SerializeField] private bool mirarDerecha;

        private void Start()
        {
            rgbody = GetComponent<Rigidbody2D>();

            gravedadIni = rgbody.gravityScale;

             veloDash = 10;
             tiempoDash = 0f;
        }


        private void Update()
        {

            direccion = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized; 

            if (Input.GetKey(KeyCode.LeftShift) && puedeMover)
            {
                velocidad = 5;
            }else
            {
                velocidad = 2;
            }
            
            if (!puedeDash)
            {
                enfriDash = enfriDash + Time.deltaTime;
                if (enfriDash >= 2f)
                {
                    puedeDash = true;
                    enfriDash = 0f;
                }
            }

            if (Input.GetKey(KeyCode.C) && puedeDash == true)
            {
                StartCoroutine(Dash());
            }

            if (direccion.x > 0 && !mirarDerecha)
            {
                girar();
            }else if (direccion.x < 0 && mirarDerecha)
            {
                girar();
            }

        }

        private void girar()
        {
            mirarDerecha = false; 
            Vector2 escala = transform.localScale; 
            escala.x *= -1;
            transform.localScale = escala;
        }

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
            if (puedeMover)
            {
                rgbody.MovePosition(rgbody.position + direccion * velocidad * Time.fixedDeltaTime);
            }

            

        }


    }
}
