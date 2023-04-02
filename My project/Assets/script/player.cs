using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{

    //public Animator animation;
    //obteniendo variables de playerarma
    public playerarma arma;
    public int daño_vulnerable;

    //movimiento
    [SerializeField] private float speed = 4f;
    [SerializeField] float jump = 20f;

    //variable que da el golpe de caida
    public float culazo = -10f;

    public Rigidbody2D player_cuerpo;

    public bool puede_saltar = true;
   
    public float fuerza = 1.2f;



    // Start is called before the first frame update
    void Start()
    {
        // animation.SetBool("caminando", false);
        //OBTENIENDO RIGIDBODY2D DEL PERSONAJE
        player_cuerpo = GetComponent<Rigidbody2D>();


    }
    

    //Update is called once per frame
    void Update()
    {
        //obteniendo daño_vulnerable
        playerarma playerarma = GetComponent<playerarma>();

        daño_vulnerable = playerarma.daño_vulnerable;


        float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("vertical");

        Vector2 jugador_mov_x = transform.position;

        jugador_mov_x = jugador_mov_x + new Vector2(horizontal, 0f) * speed * Time.deltaTime;

        transform.position = jugador_mov_x;

        if (daño_vulnerable == 1)
        {
            speed = 7;
        }else
        {
            speed = 4;
        }



        //culatazo
        if (Input.GetKey(KeyCode.Z))
        {
            ;
            Vector2 pos = new Vector3(0, -10f, 0);
            player_cuerpo.AddForce((pos * fuerza), ForceMode2D.Impulse);
            puede_saltar = true;
        }


        //salto
        if (Input.GetKey(KeyCode.Space))
        {

            if (puede_saltar == false)
            {
                return;
            }

            Vector3 pos = new Vector3(0, jump, 0);
            player_cuerpo.velocity = (pos);
            puede_saltar = false;

        }
    }

    //para que no salte mas si no cae en el ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            puede_saltar = true;

        }
        else
        {


        }






    }




}

