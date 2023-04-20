using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float velocidadBala;
    [SerializeField] private float daño;
    // Start is called before the first frame update
    void Start()
    {
        daño = 50f;
        velocidadBala = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * velocidadBala * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("enemy"))
        {
            other.GetComponent<vidaenemy>().tomarDaño(daño);
            Destroy(gameObject);

        }
    }
}
