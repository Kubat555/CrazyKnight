using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    AudioSource audioSource;
    bool attacked = false;
    public AudioClip attackSound;
    public int attackDamage = 1;
    public Transform attackPoint;
    public float AttackRange;
    public LayerMask enemyLayers;
    Animator animator;

    public float attackRate = 2f;
    float nextAtttackTime = 0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAtttackTime){
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
            attacked = true;
        }
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
    public void Attack(){
        if(attacked){
            animator.SetTrigger("Attack");
            PlaySound(attackSound);

            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);
            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<enemyController>().TakeDemage(attackDamage);
            }
            attacked = false;
            nextAtttackTime = Time.time + 1f / attackRate;
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }
}
