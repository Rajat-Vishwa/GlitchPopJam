using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Transform attackPoint;
    public Animator animator;
    public CharacterStats stats;
    public float overlapCircleRadius = 0.25f;
    public float currentHealth;

    void Start(){
        stats = gameObject.GetComponentInChildren<CharacterStats>();
        attackPoint = transform.Find("AttackPoint");
        currentHealth = stats.maxHealth;
    }

    void FixedUpdate(){
        Regen();

        if(currentHealth <= 0){
            animator = gameObject.GetComponentInChildren<Animator>();
            animator.SetTrigger("die");
            stats.alive = false;
            enabled = false;
        }
    }


    void Regen(){
        currentHealth += stats.regenRate * Time.fixedDeltaTime;
    }

    public void Attack(){
        Collider2D col = Physics2D.OverlapCircle(attackPoint.position, overlapCircleRadius);
        if(col != null){
            if(col.tag == "Player" || col.tag == "Enemy"){
                col.gameObject.GetComponent<CombatSystem>().TakeDamage(stats.attackDamage);
            }
        }
    }

    public void TakeDamage(float damage){
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetTrigger("takeDamage");
        currentHealth -= damage;
    }
}
