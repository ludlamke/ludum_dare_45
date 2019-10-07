using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5;
    [SerializeField]
    private float playerJumpHight = 5;

    public bool isContreolabe;
    public bool canJump;
    private Rigidbody2D PlayerRB;
    private float playerVelocity;

    private bool isGrounded;
    private float GroindCheak = 0.1f;
    private LayerMask ground;
    private Transform feet;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        feet = transform.GetChild(0);
        ground = LayerMask.GetMask("Ground");
        isContreolabe = false;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, GroindCheak, ground);
       // if(isContreolabe)
       // {
            player_Move();
       // }
        
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
          // if(canJump)
           // {
                PlayerJump();
          //  }
            
        }
    }

    void player_Move()
    {

        playerVelocity = playerSpeed * Input.GetAxisRaw("Horizontal");
        PlayerRB.velocity = new Vector2(playerVelocity, PlayerRB.velocity.y);

        if(PlayerRB.velocity.x > 0)
        {
            transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y);
            
        }
        else if(PlayerRB.velocity.x < 0)
        {
            transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
        }
    }

    void PlayerJump()
    {
        PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, playerJumpHight);
    }
}
