// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerAttack : MonoBehaviour
// {
//     private float timeBtwAttack;
//     public float startTimeBtwAttack;

//     public Transform attackPos;
//     public LayerMask enemy;
//     public float attackRange;
//     public int damage;
//     public Animator anim;
//     private string CurrentAnimation;

//     private bool isAttack = false;

//     [SerializeField] private AudioSource attackSound;

//     private void Update() {
//         if(isAttack){
//             if (timeBtwAttack <= 0){
//                 anim.Play("Attack");
//                 attackSound.Play();
//                 Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
//                 for(int i = 0; i < enemies.Length; i++){
//                     if(enemies[i].tag == "Enemy")
//                         enemies[i].GetComponent<enemyController>().TakeDemage(damage);
//                     else if(enemies[i].tag == "Slime2")
//                         enemies[i].GetComponent<Slime2Controller>().TakeDemage(damage);
//                 }
//                 timeBtwAttack = startTimeBtwAttack;
//             }else{
//                 timeBtwAttack -= Time.deltaTime;
//             }
//             isAttack = false;
//         }
//     }

//     public void AttackMove(){
//         isAttack = true;
//     }

//     private void OnDrawGizmosSelected() {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(attackPos.position, attackRange);
//     }

// }
