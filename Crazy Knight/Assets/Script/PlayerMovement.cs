using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    AudioSource audioSource;
   
    Animator anim;
    Rigidbody2D rb;
    public PersController controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        anim.SetFloat("yVelosity", rb.velocity.y);

        if(!controller.m_Grounded && !jump){
            anim.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Jump")){
            jump = true;
            anim.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }

    public void PlayerMove(float i){
        horizontalMove = i * runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void PlayerJump(bool j){
        jump = true;
        anim.SetBool("IsJumping", true);
    }

    public void OnLanding(){
        anim.SetBool("IsJumping", false);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
