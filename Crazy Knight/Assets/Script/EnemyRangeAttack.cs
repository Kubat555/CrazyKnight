using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public bool attack;
 

    public GameObject fireBall;
    public GameObject player;
    public Transform point;

    [SerializeField] float attackRange = 5f;
    [SerializeField] Vector2 fireDirection;

    Rigidbody2D rb;

    public float attackInterval;
    float attackTime;
    bool attacked;
    bool angry = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackTime = attackInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            angry = true;
        }
        else
        {
            angry = false;
        }

        if (attack && !attacked && angry)
        {
            Angry();
        }
        if (attacked)
        {
            attackTime -= Time.deltaTime;
            if(attackTime < 0)
            {
                attacked = false;
                attackTime = attackInterval;
            }
        }
    }


    void Attack()
    {
        GameObject projectileObject = Instantiate(fireBall, rb.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(fireDirection, 700);
    }


    void Angry()
    {
        if(player.transform.position.x - transform.position.x < 0)
        {
            fireDirection = Vector2.left;
        }
        else if(player.transform.position.x - transform.position.x > 0)
        {
           fireDirection = Vector2.right;
        }
        Attack();
        attacked = true;
    }
}
