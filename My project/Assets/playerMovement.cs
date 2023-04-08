using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;

    [SerializeField] private Vector2 movePlayer;

    private Rigidbody2D rigi;

     private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        rigi = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            playerAnimator.SetFloat("horizontal",movePlayer.x);
            playerAnimator.SetFloat("vertical",movePlayer.y);
            playerAnimator.SetFloat("Speed",movePlayer.sqrMagnitude);

    }

    void FixedUpdate(){

        rigi.MovePosition(rigi.position + movePlayer * speed * Time.fixedDeltaTime);

    }
}
