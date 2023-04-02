using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaciones : MonoBehaviour
{

    public int hitsPoints = 1;

    public float barracaliente2 = 4f;
    public float time = 0;
    public bool betica = false;
    //public Animator animation;

    // Start is called before the first frame update
    void Start()
    {

        

        //animation.SetBool("caminando", false);

       // animation.SetBool("disparo", false);

        //animation.SetBool("yamete", false);
    }

    // Update is called once per frame
    void Update()
    {
        //inicio animacion caminata derecha
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {

            //animation.SetBool("caminando", true);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

            //animation.SetBool("caminando", false);
        }

        if (Input.GetKeyDown(KeyCode.X) )
        {
            //animation.SetBool("disparo", true);
            //time += 1;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            //animation.SetBool("disparo", false);
            
        }



    }

    private void OnCollisionEnter(Collision collision)
    {

       // animation.SetBool("yamete",  collision.gameObject.tag == "enemy");
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("si le dio?");


           

        }
    }

}
