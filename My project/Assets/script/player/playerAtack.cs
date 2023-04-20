using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtack : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float dañoGolpe;

    void Start() {
        radioGolpe = 0.5f;
        dañoGolpe = 50f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.V))
        {
            atackMele();
        }        
    }

    private void atackMele()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colicionador in objetos)
        {
            if (colicionador.CompareTag("enemy"))
            {
                colicionador.transform.GetComponent<vidaenemy>().tomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

}
