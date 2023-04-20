using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveControladorAtack : MonoBehaviour
{
    [SerializeField] private Vector2 positionAtack;
    [SerializeField] private Rigidbody2D rigiAtackPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigiAtackPosition = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       positionAtack = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


      
    }

    void FixedUpdate() {
        rigiAtackPosition.MovePosition(rigiAtackPosition.position + positionAtack * 3 * Time.fixedDeltaTime);
    }
}
