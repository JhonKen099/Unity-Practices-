using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    private Vector3 objetivo;
    [SerializeField] private float anguloIni;
    [SerializeField] private Camera camera; 

    void Start() {
        anguloIni = 270;    
    }
    void Update()
    {
        objetivo = camera.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180/Mathf.PI) * anguloRadianes - anguloIni;
        transform.rotation = Quaternion.Euler(0,0, anguloGrados);
    }
}
