using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime2Controller : MonoBehaviour
{
    public float speed = 0;
    public float runSpeed = 0;
    public int jumpForse = 0;
    public int positionOfPatrol; // расстояние потруля
    public Transform point; // точка потрулирования

    bool moveingRight; 

    public GameObject player;
    public float stoppingDistance; // расстояние агрессии на игрока

    bool chill = false; // состояние покоя
    bool angry = false; // состояние агрессии
    bool goBack = false; // состояние возращения на свою точку
    // В зависимости от состояний вызывается та или иная функция

    public static bool isAttack = true;
    public int attackRange = 3;
    private Rigidbody2D enemyRb;

    public int health;

    private Animator anim;


    private void Start() {
        anim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false){
            chill = true;
            goBack = false;
        }

        if (Vector2.Distance(player.transform.position, point.position) < positionOfPatrol)
        {
            angry = true;
            chill = false;
            goBack = false;
        }else{
            angry = false;
        }
        if((Vector2.Distance(transform.position, point.position) > positionOfPatrol)){
            goBack = true;
        }
    }

    private void FixedUpdate() {
        if(chill){
            anim.SetBool("IsRun", false);
            Chill();

        }
        else if(angry){
            anim.SetBool("IsRun", true);
            Angry();
        }
        else if(goBack){
            GoBack();
        }
    }

    void Chill(){
        if(transform.position.x > point.position.x + positionOfPatrol){
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }


    void Angry(){
        if(isAttack)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
        // MoveTowards позволяет следовать за игроком.
        if((Vector2.Distance(transform.position, player.transform.position) <= attackRange && isAttack)){
            isAttack = false;
            
            // anim.Play("slime1_jump");
            enemyRb.velocity = new Vector2(enemyRb.velocity.x + (player.transform.position.x - transform.position.x), jumpForse);
            Invoke("AttackInterval", 2f);
        }
    
    }

    void GoBack(){
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    void AttackInterval(){
        isAttack = true;
    }

    public void TakeDemage(int d){
        // anim.Play("slime1_takeDamage");
        health -= d;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
