using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat : MonoBehaviour
{
private Vector3 objetivo;

    [SerializeField] private Camera camera; 
    void Update()
    {
        objetivo = camera.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180/Mathf.PI) * anguloRadianes - 90;
        transform.rotation = Quaternion.Euler(0,0, anguloGrados);
    }
}
