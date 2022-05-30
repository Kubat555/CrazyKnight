using System.Collections;
using UnityEngine;

public class PController : MonoBehaviour
{
   public Rigidbody2D rb2d;
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool groundCheck;
    public bool facingRight = true;

    private Animator anim;
    private string CurrentAnimation;
    // private bool jumpTwice = true;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if ((directionInput < 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")){
            groundCheck = true;
            // jumpTwice = true;

            if(directionInput == 0){
                ChangeAnimation("mainHeroPokoi");
            }

        }
        
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);
    }

    void ChangeAnimation(string animation){
        if(CurrentAnimation == animation) return;

        anim.Play(animation);
        CurrentAnimation = animation;
    }

    public void Move(int InputAxis)
    {
        if(InputAxis == 0){
            ChangeAnimation("mainHeroPokoi");
        }else{
            ChangeAnimation("HeroRun");
        }
        directionInput = InputAxis;
    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;

        if (groundCheck)
        {
            // ChangeAnimation("jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            groundCheck = false;
        }
        // else if(jumpTwice){
        //     rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        //     jumpTwice = false;
        // }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
