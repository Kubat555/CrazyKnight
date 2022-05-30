using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public bool rangeAttack;
    public Vector2 fireDirection;

    public GameObject fireBall;
    public GameObject player;

    Rigidbody2D rb;

    public float attackInterval;
    float attackTime;
    bool attacked;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackTime = attackInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(rangeAttack && !attacked)
        {
            Attack();
            attacked = true;
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
}
