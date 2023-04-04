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
        



        private void Start()
        {
            rgbody = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {

            direccion = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized; 

            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocidad = 5;
            }else
            {
                velocidad = 2;
            }
            


        }

        private void FixedUpdate() 
        {
            rgbody.MovePosition(rgbody.position + direccion * velocidad * Time.fixedDeltaTime);

        }


    }
}
